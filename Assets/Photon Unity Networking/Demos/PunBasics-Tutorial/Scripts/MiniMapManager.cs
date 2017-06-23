using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour {
	public GameObject miniWiddenMap;
	public GameObject widdenMap;
	public static int cullingMask;
	public static CameraClearFlags clearFlags;

	// Use this for initialization
	void Start () {
		if (miniWiddenMap == null)
			Debug.LogError ("cannnot find miniWiddenMap");
		if (widdenMap == null)
			Debug.LogError ("cannnot find miniWiddenMap");

		cullingMask = Camera.main.cullingMask;
		clearFlags = Camera.main.clearFlags;
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public void ChangeMap()
	{
		miniWiddenMap.SetActive (true);
		widdenMap.SetActive (true);
		Camera.main.clearFlags = CameraClearFlags.Nothing;
		Camera.main.cullingMask = 0;
	}

}
