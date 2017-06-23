using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionManager : Photon.MonoBehaviour {
	public GameObject switchARButton;
	public GameObject cobulin;


//	// Use this for initialization
	void Start () {
		if (switchARButton == null)
		{
			Debug.LogError ("Switch to AR button error!");
		}

	}

//	// Update is called once per frame
//	void Update () {
//
//	}

	void hit(string infoSent)
	{

		Debug.Log ("Current Collision: "+infoSent);

		// Check if is server
		if (infoSent == "RallyPoint0")
		{
			// Check which rally point!
			ExitGames.Demos.DemoAnimator.PlayerManager.isPotentialRallied = true;
			var customProperty = PhotonNetwork.player.CustomProperties;

			if (customProperty.ContainsKey ("Rallied"))
			{
				customProperty ["Rallied"] = "1";
			} else
			{
				customProperty.Add ("Rallied", "1");
			}
			PhotonNetwork.player.SetCustomProperties (customProperty);
		}

		if (infoSent == "RallyPoint1")
		{

			// Check which rally point!
			ExitGames.Demos.DemoAnimator.PlayerManager.isPotentialRallied = true;
			var customProperty = PhotonNetwork.player.CustomProperties;

			if (customProperty.ContainsKey ("Rallied"))
			{
				customProperty ["Rallied"] = "1";
			} else
			{
				customProperty.Add ("Rallied", "1");
			}
			PhotonNetwork.player.SetCustomProperties (customProperty);
		}

		if (infoSent == "Chest0")
		{
			Debug.Log ("Hit Chest 0!");
			switchARButton.SetActive (true);
			HealthManager.SetCurrentHealth (1);
		}

		if (infoSent == "Chest1")
		{
			Debug.Log ("Hit Chest 1!");
			switchARButton.SetActive (true);
			HealthManager.SetCurrentHealth (2);
		}

		if (infoSent == "Chest2")
		{
			Debug.Log ("Hit Chest 2!");
			switchARButton.SetActive (true);
			HealthManager.SetCurrentHealth (3);
		}

//		if (infoSent == "Chest3")
//		{
//			Debug.Log ("Hit Chest 3!");
//			switchARButton[3].SetActive (true);
//			currentARButton = switchARButton [3];
//		}
			

		if (infoSent == "PlayerExitRallyPoint")
		{
//			Debug.Log ("Player Exit Rally!");

			ExitGames.Demos.DemoAnimator.PlayerManager.isPotentialRallied = false;
			var customProperty = PhotonNetwork.player.CustomProperties;

			if (customProperty.ContainsKey ("Rallied"))
			{
				customProperty ["Rallied"] = "0";
			} else
			{
				customProperty.Add ("Rallied", "0");
			}
			PhotonNetwork.player.SetCustomProperties (customProperty);
		}

		if (infoSent == "PlayerExitChest")
		{
			Debug.Log ("Player Exit!");
			if (switchARButton != null)
			{
				switchARButton.SetActive (false);
			}
		}
	}

	void OnEnable()
	{
		ExitGames.Demos.DemoAnimator.PlayerManager.hit += hit;
		RallyPoint.hit += hit;
	}

	void OnDisable()
	{
		ExitGames.Demos.DemoAnimator.PlayerManager.hit -= hit;
		RallyPoint.hit -= hit;
	}
}
