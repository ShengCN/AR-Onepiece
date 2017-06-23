using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogHelper : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public static void LogInfo(object obj)
	{
		if (obj == null)
		{
			Debug.Log (obj.GetType().FullName + "does not exist!");
		}
	}

	public static void LogError(object obj)
	{
		if (obj == null)
		{
			Debug.LogError (obj.GetType().FullName + "does not exist!");
		}		
	}

	public static void LogWarining(object obj)
	{
		if (obj == null)
		{
			Debug.LogWarning (obj.GetType().FullName + "does not exist!");
		}
	}
}
