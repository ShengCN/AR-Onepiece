using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LauncherAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animation> ().Play ("Attack01");		
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
