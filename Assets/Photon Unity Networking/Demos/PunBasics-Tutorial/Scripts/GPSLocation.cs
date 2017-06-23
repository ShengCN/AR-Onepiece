using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour {
	public Text gpsText;
	public Text changedGpsText;
	float previousLatitude = 0f;
	float previousAltitude = 0f;
	public bool isDebug = false;
	public static float altitudeChanged;
	public static float latitudeChanged;

	public float DirectionDampTime = 0.01f;
	Animator animator;

	IEnumerator Start()
	{
//		animator = GetComponent<Animator> ();
		if (isDebug)
		{
			gpsText = GameObject.FindWithTag ("GPS").GetComponent<Text> ();
			changedGpsText = GameObject.FindWithTag ("GPSChanged").GetComponent<Text> ();
		}

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
//				testMovemont ();
				// Orientation Detect
//				Debug.Log("Begin orientation detection!");
//				Debug.Log ("Now the direction is: " + direction);


//				Debug.Log ("Latitude: " + Input.location.lastData.latitude + 
//					"\n" + "Altitude: " + Input.location.lastData.altitude + 
//					"\n" + "Horizontal Accuracy: " + Input.location.lastData.horizontalAccuracy + 
//					"\n" + "Time stamp: " + Input.location.lastData.timestamp);
				altitudeChanged = previousAltitude - Input.location.lastData.altitude;
				latitudeChanged = previousLatitude - Input.location.lastData.latitude;

//				Debug.Log ("Altitude Changed: " + altitudeChanged + "Latitude Changed: " + latitudeChanged);

				if (isDebug)
				{
					gpsText.text = "(" + Input.location.lastData.latitude.ToString () + "," + Input.location.lastData.altitude.ToString () + ")";
				}
//				if(altitudeChanged !=0 || latitudeChanged != 0)
//					changedGpsText.text = "("+  latitudeChanged.ToString() + "," + altitudeChanged.ToString()+")";

				previousAltitude = Input.location.lastData.altitude;
				previousLatitude = Input.location.lastData.latitude;

//				// Check if vector happens
//				if (altitudeChanged != 0 || latitudeChanged != 0)
//				{
//					var degree = direction.y / direction.x;
//					if (degree > 0)
//					{
//						AnimatorSimulation (1f,degree);
//					} else
//					{
//						AnimatorSimulation (1f,-degree);
//					}
//
//				}
//				AnimatorSimulation (1f,0f);
//				var newLocation = transform.position;
//				newLocation.x += altitudeChanged * speed;
//				newLocation.z += latitudeChanged * speed;
//				transform.position = newLocation;
			}
		}
	}

	void StopLocation()
	{
		Input.location.Stop ();
	}

//	void AnimatorSimulation(float x, float direction)
//	{
////		animator.SetFloat ("Speed", x);
////		animator.SetFloat( "Direction", direction, DirectionDampTime, Time.deltaTime );
//		animator.Play("Run");
//	}
//
//	void testMovemont()
//	{
//		// deal with movement
//		float h = Input.GetAxis("Horizontal");
//		float v = Input.GetAxis("Vertical");
//
//		// prevent negative Speed.
//		if( v < 0 )
//		{
//			v = 0;
//		}
//
//		// set the Animator Parameters
////		animator.SetFloat( "Speed", h*h+v*v );
////		animator.SetFloat ("Direction", h, DirectionDampTime, Time.deltaTime);
//		var newLocation = transform.position;
//		Debug.Log ("New location is: " + newLocation);
//		newLocation.x += h * speed;
//		newLocation.z += v * speed;
//		newLocation.y = 0.6f;
//		transform.position = newLocation;
//	}
		
}
