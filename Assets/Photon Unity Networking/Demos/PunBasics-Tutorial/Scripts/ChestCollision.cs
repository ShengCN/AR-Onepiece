﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChestCollision : Photon.PunBehaviour {
	public static Action<String> hit;

	//	// Use this for initialization
	//	void Start () {
	//		
	//	}
	//	
	//	// Update is called once per frame
	//	void Update () {
	//		
	//	}

//	void OnTriggerStay(Collider other)
//	{
//		if (!photonView.isMine)
//			return;
//
//		if (hit != null)
//		{
//			String name = other.tag;
//			hit (name);
//		}
//	}
//
//	void OnTriggerExit(Collider other)
//	{
//		if (!photonView.isMine)
//			return;
//		
//		Debug.Log ("Exit!");
//		if (hit != null)
//		{
//			String info = "PlayerExit";
//			hit (info);
//		}
//	}
}
