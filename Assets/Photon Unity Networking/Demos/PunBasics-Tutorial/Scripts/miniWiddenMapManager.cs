using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniWiddenMapManager : MonoBehaviour {
	public GameObject miniWiddenMap;
	public GameObject widdenMap;

	// Use this for initialization
	void Start () {
		if (miniWiddenMap == null)
		{
			Debug.LogError ("Not found MiniWiddenMap!");
		}

		if (widdenMap == null)
		{
			Debug.LogError ("Not found MiniWiddenMap!");
		}
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public void ResetMap()
	{
		miniWiddenMap.SetActive (false);
		widdenMap.SetActive (false);
		Camera.main.cullingMask = MiniMapManager.cullingMask;
		Camera.main.clearFlags = MiniMapManager.clearFlags;
	}
}
