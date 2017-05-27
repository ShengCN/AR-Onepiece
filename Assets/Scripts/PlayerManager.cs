using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : Photon.PunBehaviour, IPunObservable {
	public GameObject Beams;
	public int currentScore = 0;
	bool isFiring;

	public static GameObject LocalPlayerInstance;
	public GameObject PlayerUiPrefab;

	void Awake()
	{
		if (photonView.isMine)
		{
			PlayerManager.LocalPlayerInstance = this.gameObject;
		} 

		DontDestroyOnLoad (this.gameObject);

		if (Beams == null)
		{
			Debug.LogError ("<Color=Red><a>Missing</a></Color> Beams Reference.", this);
		} else
		{
			Beams.SetActive (false);
		}
	}


	// Use this for initialization
	void Start () {
		if (PlayerUiPrefab != null)
		{
			GameObject _uiGo = Instantiate (PlayerUiPrefab) as GameObject;
			_uiGo.SendMessage ("SetTarget", this, SendMessageOptions.RequireReceiver);
		} else
		{
			Debug.LogWarning ("<Color=Red><a>Missing</a></Color> PlayerUiPrefab reference on player Prefab.", this);
		}
			

		CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork> ();

		if (_cameraWork != null)
		{
			if (photonView.isMine)
			{
				_cameraWork.OnStartFollowing ();
			}
		} else
		{
			Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.",this);
		}

		UnityEngine.SceneManagement.SceneManager.sceneLoaded += (scene, loadingMode) => 
		{
			this.CalledOnLeveleWasLoaded(scene.buildIndex);	
		} ;
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine)
		{
			ProcessInput ();
		}
		if (Beams != null && isFiring != Beams.GetActive ())
		{
			Beams.SetActive (isFiring);
		}
	}

	void ProcessInput()
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			if (!isFiring)
				isFiring = true;
		}

		if (Input.GetButtonUp ("Fire1"))
		{
			if (isFiring)
				isFiring = false;
		}
	}

	void OnLevelWasLoaded(int level)
	{
		this.CalledOnLeveleWasLoaded (level);
		GameObject _uiGo = Instantiate (this.PlayerUiPrefab) as GameObject;
		_uiGo.SendMessage ("SetTarget", this, SendMessageOptions.RequireReceiver);
	}

	void CalledOnLeveleWasLoaded(int level)
	{
		if (this != null)
		{
			if (!Physics.Raycast (transform.position, -Vector3.up, 5f))
			{
				transform.position = new Vector3 (0f, 5f, 0f);
			}
		}
	}

	#region IPunObservable implementation

	void IPunObservable.OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext (isFiring);
			stream.SendNext (currentScore);
		} else
		{
			this.isFiring = (bool)stream.ReceiveNext ();
			this.currentScore = (int)stream.ReceiveNext ();
		}
	}

	#endregion
}
