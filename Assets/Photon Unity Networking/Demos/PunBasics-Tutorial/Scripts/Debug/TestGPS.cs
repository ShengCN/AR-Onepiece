using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGPS: MonoBehaviour {
	public Text gpsText;
	public Text changedGpsText;
	float previousLatitude = 0f;
	float previousAltitude = 0f;

	public static float altitudeChanged;
	public static float latitudeChanged;

	public float DirectionDampTime = 0.01f;
	Animator animator;
	CharacterController character;
	public float speed = 100;

	IEnumerator Start()
	{
		//		animator = GetComponent<Animator> ();
		//		gpsText = GameObject.FindWithTag("GPS").GetComponent<Text>();
		//		changedGpsText = GameObject.FindWithTag ("GPSChanged").GetComponent<Text>();

		Debug.Log ("GPS Start!");

		// Check if user has location service
		if (!Input.location.isEnabledByUser)
		{
			Debug.Log ("GPS 未开启，等待开启");
			yield return new  WaitForSeconds (1f);

		}
		// Start service
		Input.location.Start (1f,1f);

		// Wait until service intializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		if (maxWait < 1)
		{
			Debug.Log ("Time out");
			yield break;
		}

		previousAltitude = Input.location.lastData.altitude;
		previousLatitude = Input.location.lastData.latitude;
		character = GetComponent<CharacterController> ();

		StartCoroutine (UpdateGPSLocation (0.1f));
	}

	//	// Update is called once per frame
	//	void Update () {
	//		
	//	}

	IEnumerator UpdateGPSLocation(float frequency)
	{
		while (true)
		{
			yield return new  WaitForSeconds (frequency);

			// Connection has failed
			if (Input.location.status == LocationServiceStatus.Failed)
			{
				Debug.Log ("Unable to determine device location");
				yield break;
			} else
			{
				altitudeChanged = previousAltitude - Input.location.lastData.altitude;
				latitudeChanged = previousLatitude - Input.location.lastData.latitude;

				Debug.Log ("Altitude Changed: " + altitudeChanged + "Latitude Changed: " + latitudeChanged);
				gpsText.text = "("+  Input.location.lastData.latitude.ToString() + "," + Input.location.lastData.altitude.ToString()+")";

				if(altitudeChanged !=0 || latitudeChanged != 0)
					changedGpsText.text = "("+  latitudeChanged.ToString() + "," + altitudeChanged.ToString()+")";

				// Test Move
				// Orientation


				// Move
				Vector3 move = new Vector3(altitudeChanged,0f,latitudeChanged);
				move = transform.TransformDirection (move);
				Vector3 newMove = new Vector3 (move.x * speed, 0f, move.z * speed);
				character.Move (newMove);

				previousAltitude = Input.location.lastData.altitude;
				previousLatitude = Input.location.lastData.latitude;

			}
		}
	}

	void StopLocation()
	{
		Input.location.Stop ();
	}

}
