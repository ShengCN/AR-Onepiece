using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		setAllChildrenIsTrigger (this.transform,true);	
	}
	
	// Update is called once per frame
//	void Update () {
//		
//	}

	void setAllChildrenIsTrigger(Transform trans,bool isTrigger)
	{
		foreach (Transform child in trans)
		{
//			Debug.Log (child.gameObject.name);
			var collider = child.GetComponent<BoxCollider> ();
			if (collider != null)
			{
//				Debug.Log (child.gameObject.name + "Set to trigger");
				collider.isTrigger = isTrigger;
			}
			setAllChildrenIsTrigger (child, isTrigger);
		}
	}

}
