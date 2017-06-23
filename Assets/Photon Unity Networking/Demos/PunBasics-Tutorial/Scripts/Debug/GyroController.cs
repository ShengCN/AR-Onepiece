using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : Photon.MonoBehaviour  {

	private bool gyroEnabled;
	private Gyroscope gyro;

	private Quaternion rot;

	// Use this for initialization
	void Start () {
		gyroEnabled = EnableGyro ();


	}
	
	// Update is called once per frame
	void Update () {
		// Prevent control is connected to Photon and represent the localPlayer
		if( photonView.isMine == false && PhotonNetwork.connected == true )
		{
			return;
		}

		if (gyroEnabled)
		{
			var tmp = transform.localRotation;

			tmp = gyro.attitude * rot;
			tmp.x = 0;
			tmp.z = 0;

			transform.localRotation = tmp;
//			transform.LookAt (transform.position - );
		}
	}

	bool EnableGyro()
	{
		if (SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;

//			transform.rotation = Quaternion.Euler (90f, 90f, 0f);
			rot = new Quaternion (1, 0, 0, 0);

			return true;
		}

		return false;
	}
		
}
