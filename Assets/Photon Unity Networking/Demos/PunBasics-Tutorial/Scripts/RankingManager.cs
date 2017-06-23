using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingManager : Photon.MonoBehaviour {

	public List<Text> rankings;
	[Tooltip("The UI Loader Anime")]
	public ExitGames.Demos.DemoAnimator.LoaderAnime loaderAnime;
	public GameObject LoadingScene;
	public GameObject RankingScene;

	private bool isCalculateFinished;
	void Awake()
	{
		if (loaderAnime==null)
		{
			Debug.LogError("<Color=Red><b>Missing</b></Color> loaderAnime Reference.",this);
		}
	}

	// Use this for initialization
	void Start () {
		CalculateRanking ();
	}
		
	public void QuitApplication()
	{
		Application.Quit();
	}

	void InitializeRanking()
	{
		isCalculateFinished = false;
		LoadingScene.SetActive (true);
		RankingScene.SetActive (false);
		loaderAnime.StartLoaderAnimation();
		CalculateRanking ();
	}


	void CalculateRanking()
	{

		Dictionary<String,String> scorePlayerDic = new Dictionary<String,String> ();
		Dictionary<String, String> playerNames = new Dictionary<String,String> ();

		foreach (var p in PhotonNetwork.playerList)
		{
			playerNames.Add (p.ID.ToString(), p.NickName);
		}

		var playerProperty = PhotonNetwork.room.CustomProperties;

		for (var id = 1; id < 5;++id)
		{
			if (playerProperty.ContainsKey (Convert.ToString (id)))
			{
				scorePlayerDic.Add (Convert.ToString (id), Convert.ToString (playerProperty [Convert.ToString (id)]));
				Debug.LogError (id + " 得分是：" + playerProperty [Convert.ToString (id)]);
			} else
			{
				Debug.LogError ("Not find " + id);
			}
		}

		var dicSort = scorePlayerDic.OrderByDescending (s =>  s.Value);

		foreach (var s in dicSort)
		{
			Debug.Log ("In dicSort"+s.Key + " : " + s.Value);
		}

		foreach (var p in playerNames)
		{
			Debug.Log ("In PlayerNames "+p.Key + " : " + p.Value);
		}

		// Finished!
		isCalculateFinished = true;
		loaderAnime.StopLoaderAnimation();
		LoadingScene.SetActive (false);
		RankingScene.SetActive (true);


		int count = 0;
		foreach(var s in dicSort) 
		{
			Debug.Log (s.Key);
			if (s.Key == "curScn")
				continue;
			else
			{
				rankings [count++].text = playerNames [s.Key];
				Debug.Log (playerNames [s.Key]+" 获得 "+s.Value+" 分！");
			}
		}
	}
}
