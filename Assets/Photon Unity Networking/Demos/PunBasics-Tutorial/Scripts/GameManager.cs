// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Launcher.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in "PUN Basic tutorial" to handle typical game management requirements
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using ExitGames.Client.Photon;
using System.Linq;

namespace ExitGames.Demos.DemoAnimator
{
	/// <summary>
	/// Game manager.
	/// Connects and watch Photon Status, Instantiate Player
	/// Deals with quiting the room and the game
	/// Deals with level loading (outside the in room synchronization)
	/// </summary>
	public class GameManager : Photon.MonoBehaviour {

		#region Public Variables

		static public GameManager Instance;
		public GameObject dialog;
		public Text dialogInformation;
		public GameObject gameScene;
		public GameObject RankingScene;
		public GameObject spawnPoint1;
		public GameObject spawnPoint2;
		public GameObject spawnPoint3;
		public GameObject spawnPoint4;
		public List<GameObject> chestSpawPoint;
		public List<GameObject> rallySpawPoint;

		public GameObject arScene;
		public GameObject arCanvas;
		public Text GameTimingText;
		public GameObject rallyPoint1;
		public GameObject rallyPoint2;
		public Text timingText;
		public List<GameObject> chessPrefab;
		public List<GameObject> rallyPointPrefab;
//		public GameObject cobulinImgTarget;
		public float height;
		public static bool isARCounting;

		[Tooltip("The prefab to use for representing the player")]
		public GameObject playerPrefab;
		public GameObject comboTimesPrefab;
		private bool isGameCounting;
		private bool isGameOver;
		private float ARtimeLeft = 0f;
		private bool isRoundOneMessaged;
		private bool isRoundTwoMessaged;
		private bool isRoundThreeMessaged;

		public float GameTime;
		public static float GameTimeLeft;
		public float RoundGameTime;
		public static bool isPlayerEnough;
		public static List<string> playersNames;
		private List<Text> rankings;
		Dictionary<String, String> playerNames;
		public GameObject chestMission;
		private GameObject healthManagerInstance;

		#endregion

		#region Private Variables

		private GameObject instance;

		#endregion

		#region MonoBehaviour CallBacks

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
		void Start()
		{
			Instance = this;
			healthManagerInstance = HealthManager.localHealthInstance;
			PlayerPrefs.SetInt ("Score",0);
			height = 2.89f;
			playersNames = new List<string> ();
			GameTime = 910f;
			RoundGameTime = 300f;
			GameTimeLeft = GameTime;


			// in case we started this demo with the wrong scene being active, simply load the menu scene
			if (!PhotonNetwork.connected)
			{
				SceneManager.LoadScene("PunBasics-Launcher");

				return;
			}

			if (playerPrefab == null) { // #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.
				
				Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
			} else {
				// Initilize scene
				if (gameScene != null)
				{
					gameScene.SetActive (true);
					arScene.SetActive (false);
					arCanvas.SetActive (false);
				}else
				{
					Debug.LogError ("Not found arScene or gameScene!");
				}

				// Initilize player
				if (PlayerManager.LocalPlayerInstance==null)
				{
					Debug.Log("We are Instantiating LocalPlayer from "+SceneManagerHelper.ActiveSceneName);

					// we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.
					Debug.Log("Current Player ID: "+PhotonNetwork.player.ID);

					switch(PhotonNetwork.player.ID)
					{
					case 1:
						InstantiatePlayer (spawnPoint1.transform);
						break;
					case 2:
						InstantiatePlayer (spawnPoint2.transform);						
						break;
					case 3:
						InstantiatePlayer (spawnPoint3.transform);
						break;
					case 4:
						InstantiatePlayer (spawnPoint4.transform);
						break;
					default:
						break;
					}
				}else{

					Debug.Log("Ignoring scene load for "+ SceneManagerHelper.ActiveSceneName);
				}
			}

		}

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
		void Update()
		{
			// "back" button of phone equals "Escape". quit app if that's pressed
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				QuitApplication();
			}

			CheckTiming ();
		}

		void InstantiatePlayer(Transform trans)
		{
			PhotonNetwork.Instantiate(this.playerPrefab.name, trans.position, trans.rotation, 0);

			if (PhotonNetwork.isMasterClient)
			{
				// Instantiate Chest
				int count = 0;
				foreach (var csp in chestSpawPoint)
				{
					PhotonNetwork.Instantiate (this.chessPrefab [count].name, csp.transform.position, csp.transform.rotation, 0);
					count++;
				}

				count = 0;
				// Instantiate Rally Point
				foreach (var rp in rallySpawPoint)
				{
					PhotonNetwork.Instantiate (this.rallyPointPrefab [count].name, rp.transform.position, rp.transform.rotation, 0);
					count++;
				}

				// Instantiate Cobulin img target
//				PhotonNetwork.Instantiate(cobulinImgTarget.name,cobulinImgTarget.transform.position,cobulinImgTarget.transform.rotation,0);
//
				var property = PhotonNetwork.room.CustomProperties;
				if (property.ContainsKey ("health1"))
				{
					property ["health1"] = "100.0";
				} else
				{
					property.Add ("health1", "100.0");
				}
				if (property.ContainsKey ("health2"))
				{
					property ["health2"] = "100.0";
				} else
				{
					property.Add ("health2", "100.0");
				}
				if (property.ContainsKey ("health3"))
				{
					property ["health3"] = "100.0";
				} else
				{
					property.Add ("health3", "100.0");
				}

				PhotonNetwork.room.SetCustomProperties (property);
			}
			StartGameTiming ();
		}

		#endregion

		#region Photon Messages

		/// <summary>
		/// Called when a Photon Player got connected. We need to then load a bigger scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public void OnPhotonPlayerConnected( PhotonPlayer other  )
		{
			Debug.Log( "OnPhotonPlayerConnected() " + other.NickName); // not seen if you're the player connecting

			if ( PhotonNetwork.isMasterClient ) 
			{
				Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected

				LoadArena();
			}
		}

		/// <summary>
		/// Called when a Photon Player got disconnected. We need to load a smaller scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public void OnPhotonPlayerDisconnected( PhotonPlayer other  )
		{
			Debug.Log( "OnPhotonPlayerDisconnected() " + other.NickName ); // seen when other disconnects

			if ( PhotonNetwork.isMasterClient ) 
			{
				Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected
				
				LoadArena();
			}
		}

		/// <summary>
		/// Called when the local player left the room. We need to load the launcher scene.
		/// </summary>
		public virtual void OnLeftRoom()
		{
			
			SceneManager.LoadScene("PunBasics-Launcher");
		}

		#endregion

		#region Public Methods

		public void LeaveRoom()
		{
			Debug.LogError ("Called on left room!");
			PhotonNetwork.LeaveRoom();
		}

		public void QuitApplication()
		{
			Application.Quit();
		}

		public void SwitchToGameScene()
		{
			if (arScene!=null)
			{
				// todo
				// Calculate scores!
				Debug.Log("Score this round: " + PlayerManager.LocalPlayerInstance.GetComponent<PlayerManager>().scorePerRound);

				arScene.SetActive (false);
				arCanvas.SetActive (false);
				gameScene.SetActive (true);
				isARCounting = false;
			} else
			{
				Debug.LogError ("Not found arScene or gameScene!");
			}
		}

		public void SwitchToARScene()
		{
			if (gameScene != null)
			{
				gameScene.SetActive (false);
				arScene.SetActive (true);
				arCanvas.SetActive (true);
				StartARTiming ();
				isARCounting = true;
			}
			else
			{
				Debug.LogError ("Not found arScene or gameScene!");
			}
		}

		public void hitCobullin()
		{
			Debug.Log ("Hit cobullin!");
			if (HealthManager.isTrackable)
			{
				Debug.Log ("Is trackable");
				if (HealthManager.localHealthInstance != null)
				{
					HealthManager.localHealthInstance.GetComponent<HealthManager> ().hitOnce ();
				} else
				{
					Debug.LogError ("Local cobulin instance not found!");
				}

				var score = PlayerManager.LocalPlayerInstance.GetComponent<PlayerManager>().scorePerRound + 1f;
				if (HealthManager.localHealthInstance.GetComponent<HealthManager> ().currentHealth>0)
				{
					var combo = Instantiate (comboTimesPrefab);
					combo.GetComponent<Text> ().text += score.ToString ();
					combo.transform.SetParent (arCanvas.transform, false);
					var comboAnimation = combo.GetComponent<Animation> ();
					comboAnimation.Play ();

				} else
				{
					// Cobullin dead
					Debug.Log ("This round score: " + score);

//					SwitchToGameScene ();
					return;
				}
			} else
				return;
		}

		#endregion

		#region Private Methods
		void CalculateScore()
		{
			Debug.LogError ("Current player:"+PlayerManager.currentPeerID);
			var playerManagerInstance = PlayerManager.LocalPlayerInstance.GetComponent<PlayerManager> ();

			var score = playerManagerInstance.Score;
			if (!PlayerManager.isBothRallied)
			{
				score += playerManagerInstance.scorePerRound;
			} else
			{
				score += playerManagerInstance.scorePerRound * 3;
			}
			Debug.Log ("这一轮得分：" + playerManagerInstance.scorePerRound);
			Debug.Log ("现在得分：" + playerManagerInstance.Score);

			playerManagerInstance.Score = score;
			playerManagerInstance.scorePerRound = 0;

			playerManagerInstance.UpdateScoreOnPhoton ();
		}

		void LoadArena()
		{
			Debug.LogError ("Call load Arena");

			if ( ! PhotonNetwork.isMasterClient ) 
			{
				Debug.LogError( "PhotonNetwork : Trying to Load a level but we are not the master Client" );
			}

			Debug.Log( "PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount ); 

			if (isGameOver)
			{
				PhotonNetwork.LoadLevel(5);
			} else
			{
				PhotonNetwork.LoadLevel ("PunBasics-Room for " + PhotonNetwork.room.PlayerCount);
			}
		}

		void StartARTiming()
		{
			ARtimeLeft = 30f;

//			timingText.text = ARtimeLeft.ToString ();
			Debug.Log ("Start counting!");
		}

		void StartGameTiming()
		{
			if (PhotonNetwork.room.PlayerCount < 4)
			{
				Debug.Log ("需要4名玩家才能开始游戏");
				return;
			}

			// Reset score!
//			ResetScore();

			playerNames = new Dictionary<String,String> ();
			Debug.Log ("开始载入其他玩家");
			foreach (var p in PhotonNetwork.playerList)
			{
				Debug.Log ("载入" + p.ID.ToString()+ " "+ p.NickName);
				playerNames.Add (p.ID.ToString(), p.NickName);
			}

			EnableRally ();
			GameTimeLeft = GameTime;
			isGameCounting = true;
//			GameTimingText.text = GameTimeLeft.ToString ();
			isPlayerEnough = true;
		}

		void CheckTiming()
		{

			if (PhotonNetwork.playerList.Length < 4)
			{
//				Debug.LogError ("需要4名玩家才能开始游戏");
				isPlayerEnough = false;
				return;
			} 

			// Game Timing
			if (!isGameCounting)
				return;

			if (GameTimeLeft < 0f)
			{
				Debug.Log ("Game Over!");
				isGameCounting = false;
				// Finish Game
				// Todo
				// Load Ranking Scene
				isGameOver = true;
				LoadArena ();
			} else
			{
				GameTimeLeft -= Time.deltaTime;
//				GameTimingText.text = GameTimeLeft.ToString ();

				// Round 1
				if (GameTime - GameTimeLeft < RoundGameTime && isPlayerEnough)
				{
					if (isRoundOneMessaged)
					{
						//todo
						CheckIfBothRallied(1);

					} else
					{
						isRoundOneMessaged = true;
						PlayerManager.isBothRallied = false;
						string peerName = SelectPeer (1);
						string info = "如果和 "+ peerName+" 集结点汇合\n再去找哥布林,可以加分哦！";
						OpenDialog (info);
						Debug.Log("Round One has been opened!");
					}
				}

				// Round 2
				if (GameTime - GameTimeLeft < 2*RoundGameTime && GameTime - GameTimeLeft>RoundGameTime && isPlayerEnough)
				{
					if (isRoundTwoMessaged)
					{
						//todo
						CheckIfBothRallied(2);

					} else
					{
						CalculateScore ();
						isRoundTwoMessaged = true;

						// Goblin health reset
						healthManagerInstance.GetComponent<HealthManager>().ResetHealth(1);
						healthManagerInstance.GetComponent<HealthManager>().ResetHealth(2);
						healthManagerInstance.GetComponent<HealthManager>().ResetHealth(3);

						PlayerManager.isBothRallied = false;
						string peerName = SelectPeer (2);
						string info = "如果和 "+ peerName+" 集结点汇合\n再去找哥布林,可以加分哦！";
						OpenDialog (info);
						Debug.Log("Round Two has been opened!");
					}
				}

				// Round 3
				if (GameTime - GameTimeLeft < 3*RoundGameTime && GameTime - GameTimeLeft>2*RoundGameTime && isPlayerEnough)
				{
					if (isRoundThreeMessaged)
					{
						//todo
						CheckIfBothRallied(3);

					} else
					{
						CalculateScore ();
						isRoundThreeMessaged = true;
						PlayerManager.isBothRallied = false;
						string peerName = SelectPeer (3);
						string info = "如果和 "+ peerName+" 集结点汇合\n再去找哥布林,可以加分哦！";
						OpenDialog (info);
						Debug.Log("Round Three has been opened!");
					}
				}

				// After Round 3
				if (GameTime - GameTimeLeft >= 3*RoundGameTime && isPlayerEnough)
				{
					CalculateScore ();

				}
			}


			// If has AR Timing
			if (isARCounting == false)
			{
				return;
			}

			if (ARtimeLeft < 0)
			{
				Debug.Log ("Time is running out!");
				isARCounting = false;

				Debug.Log ("Now the player score is: " + PlayerPrefs.GetInt ("Score"));
				SwitchToGameScene ();
				return;
			}

			ARtimeLeft -= Time.deltaTime;
//			timingText.text = ARtimeLeft.ToString ();
		}

		#endregion

		void EnableRally()
		{
			if (rallyPoint1 && rallyPoint2)
			{
				rallyPoint1.SetActive (true);
				rallyPoint2.SetActive (true);
			}
		}

		void DisableRally()
		{
			if (rallyPoint1 && rallyPoint2)
			{
				rallyPoint1.SetActive (false);
				rallyPoint2.SetActive (false);			
			}
		}

		void OpenDialog(String information)
		{
			Debug.LogError ("Dialog open!" + "Information now: "+information);

			dialog.SetActive (true);
			dialogInformation.text = information;
		}

		string SelectPeer(int round)
		{
			var currentPlayerID = PhotonNetwork.player.ID.ToString();
			switch (currentPlayerID)
			{
			case "1":
				switch (round)
				{
				case 1:
					PlayerManager.currentPeerID = 2;
					return playerNames ["2"] + "在红色";
				case 2:
					PlayerManager.currentPeerID = 3;
					return playerNames ["3"] + "在红色";
				case 3:
					PlayerManager.currentPeerID = 4;
					return playerNames ["4"] + "在红色";
				default:
					return "";
				}
			case "2":
				switch (round)
				{
				case 1:
					PlayerManager.currentPeerID = 1;
					return playerNames ["1"] + "在红色";
				case 2:
					PlayerManager.currentPeerID = 4;
					return playerNames ["4"] + "在绿色";
				case 3:
					PlayerManager.currentPeerID = 3;
					return playerNames ["3"] + "在绿色";
				default:
					return "";
				}
			case "3":
				switch (round)
				{
				case 1:
					PlayerManager.currentPeerID = 4;
					return playerNames ["4"] + "在绿色";
				case 2:
					PlayerManager.currentPeerID = 1;
					return playerNames ["1"]+ "在红色";
				case 3:
					PlayerManager.currentPeerID = 2;
					return playerNames ["2"]  + "在绿色";
				default:
					return "";
				}
			case "4":
				switch (round)
				{
				case 1:
					PlayerManager.currentPeerID = 3;
					return playerNames ["3"] + "在绿色";
				case 2:
					PlayerManager.currentPeerID = 2;
					return playerNames ["2"] + "在绿色";
				case 3:
					PlayerManager.currentPeerID = 1;
					return playerNames ["1"]+ "在红色";

				default:
					return "";
				}
			default:
				return "";
			}
		}

		public void MakeChestMission()
		{
			chestMission.SetActive (false);
		}

		void CheckIfBothRallied(int round)
		{
			// If has been rallied, then do not check
			if (PlayerManager.isBothRallied)
				return;

			// Check self
			if (!PlayerManager.isPotentialRallied)
				return;
			
			// Check others
			if (PlayerManager.currentPeerID == 0)
				return;
			
			var peerID = PlayerManager.currentPeerID;
			var otherPlayers = PhotonNetwork.otherPlayers;
			Debug.Log ("开始确认！");

			foreach (var p in otherPlayers)
			{
				if (p.ID == peerID)
				{
					var property = p.CustomProperties;

					foreach(var pItem in property)
					{
						Debug.Log (pItem.Key+ "---->" + pItem.Value);

						if ((string)pItem.Key == "Rallied")
						{
							if ((string)pItem.Value == "1")
							{
								PlayerManager.isBothRallied = true;
								Debug.Log ("你成功和 " + p.NickName +" 结盟！快去找哥布林吧！");
								OpenDialog ("你成功和 " + p.NickName +" 结盟！快去找哥布林吧！");
							}
						}
					}
				}
			}
		}

		void ResetScore()
		{
			var personalProperties = PhotonNetwork.room.CustomProperties;
			string tmp = "0";
			if (personalProperties.ContainsKey (PhotonNetwork.player.ID.ToString()))
			{
				personalProperties.Remove (PhotonNetwork.player.ID.ToString());
			} 
//			else
//			{
//				personalProperties.Add (PhotonNetwork.player.ID.ToString(), tmp);
//			}
			PhotonNetwork.room.SetCustomProperties (personalProperties);
		}
	}

}