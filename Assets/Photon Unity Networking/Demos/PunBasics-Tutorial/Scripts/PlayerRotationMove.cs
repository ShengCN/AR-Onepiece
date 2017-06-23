using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationMove : Photon.MonoBehaviour {



	// Update is called once per frame
	void Update () {
		Debug.Log ("Begin Rotation detection!********************");

		Vector3 direction = Vector3.zero;
		direction.x = -Input.acceleration.y;
		direction.z = -Input.acceleration.x;

		if (direction.sqrMagnitude > 1)
		{
			direction.Normalize ();
		}

		direction *= Time.deltaTime;
		Debug.Log ("Direction: "+ direction);

		this.transform.Translate (direction * speed);
	}
	public float speed = 10f;
	void changeRotation()
	{
		Debug.Log ("Begin Rotation detection!********************");

		Vector3 direction = Vector3.zero;
		direction.x = -Input.acceleration.y;
		direction.z = -Input.acceleration.x;

		if (direction.sqrMagnitude > 1)
		{
			direction.Normalize ();
		}

		direction *= Time.deltaTime;
		Debug.Log ("Direction: "+ direction);

		this.transform.Translate (direction * speed);
	}
}
