using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour {

	// Use this for initialization
	void AddTimes () {
		ExitGames.Demos.DemoAnimator.PlayerManager.LocalPlayerInstance.GetComponent<ExitGames.Demos.DemoAnimator.PlayerManager>().scorePerRound += 1;
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}

//	void Start()
//	{
//	}

//	// Update is called once per frame
//	void Update () {
//		
//	}
}
