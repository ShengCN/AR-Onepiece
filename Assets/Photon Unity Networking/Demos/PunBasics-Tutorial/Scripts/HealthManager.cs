using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class HealthManager : Photon.PunBehaviour{
	public static GameObject localHealthInstance;
	public GameObject CobulinGameObject;
	public float health_1 ;
	public float health_2 ;
	public float health_3 ;

	private static int currentID;
	public float currentHealth;
	public float speed = 2f;
	public GameObject healthBar;
	public GameObject healthBackground;
	private TrackableBehaviour mTrackableBehaviour;
	public static bool isTrackable = false;
	public AudioSource audioSource;
	public AudioClip scream;
	private List<int> healthList;

	/// <summary>
	/// MonoBehaviour method called on GameObject by Unity during early initialization phase.
	/// </summary>
	public void Awake()
	{
		localHealthInstance = gameObject;
//		healthBackground = GameObject.FindWithTag ("HealthBackground");
//		healthBar = GameObject.FindWithTag ("HealthBar");
	}

	void Start()
	{
		health_1 = 100f;
		health_2 = 100f;
		health_3 = 100f;
		currentHealth = 100f;
		audioSource = CobulinGameObject.GetComponent<AudioSource> ();

		healthList = new List<int>();
	}
		

//	// Update is called once per frame
	void Update () {
		// Update health value
		var property = PhotonNetwork.room.CustomProperties;

		health_1 = float.Parse((string)property ["health1"]);
		health_2 = float.Parse((string)property ["health2"]);
		health_3 = float.Parse((string)property ["health3"]);

		isTrackable = DefaultTrackableEventHandler.isFound;
		if (isTrackable)
		{ 
			switch (currentID)
			{
			case 1:
				currentHealth = health_1;
				break;
			case 2:
				currentHealth = health_2;
				break;
			case 3:
				currentHealth = health_3;
				break;
			default:
				break;
			}

			if (Input.anyKey)
			{
				Debug.Log ("Current health: " + currentHealth);
				Debug.Log ("Health1: " + health_1);
				Debug.Log ("Health2: " + health_2);
				Debug.Log ("Health3: " + health_3);
			}

			Vector3 scale = new Vector3 (currentHealth/100f, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
			healthBar.transform.localScale = scale;

			healthBar.SetActive (true);
			healthBackground.SetActive (true);
		} else
		{
			healthBar.SetActive (false);	
			healthBackground.SetActive (false);
		}

	}

	public void hitOnce()
	{
		if (isTrackable == false)
			return;

		if (currentHealth > 0f)
		{
			Debug.Log ("Hit the "+ currentID);

			audioSource.PlayOneShot (scream,0.8f);
			currentHealth -= 1f;

			var property = PhotonNetwork.room.CustomProperties;
			switch (currentID)
			{
			case 1:
				health_1 = currentHealth;
				property ["health1"] = health_1.ToString ();

				break;
			case 2:
				health_2 = currentHealth;
				property ["health2"] = health_2.ToString ();
				break;
			case 3:
				health_3 = currentHealth;
				property ["health3"] = health_3.ToString ();
				break;
			default:
				break;
			}
			PhotonNetwork.room.SetCustomProperties (property);

//			var tmpX = healthBar.transform.localScale.x;
//			tmpX -= 0.02f;
//			Vector3 scale = new Vector3 (tmpX, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
//			healthBar.transform.localScale = scale;
			PlayDamage ();

		} else
		{
			SetToDead ();
			return;
		}
	}

	public void ResetHealth(int id)
	{
		if (id < 1 || id > 3)
		{
			Debug.Log ("Health ID Error!");
			return;
		}
			
		healthList [id-1] = 100;

		var property = PhotonNetwork.room.CustomProperties;
		switch (id)
		{
		case 1:
			health_1 = currentHealth;
			property ["health1"] = health_1.ToString ();

			break;
		case 2:
			health_2 = currentHealth;
			property ["health2"] = health_2.ToString ();
			break;
		case 3:
			health_3 = currentHealth;
			property ["health3"] = health_3.ToString ();
			break;
		default:
			break;
		}

		PhotonNetwork.room.SetCustomProperties (property);
	}

	public static void SetCurrentHealth(int id)
	{
		switch (id)
		{
		case 1:
			currentID = id;
			Debug.Log ("Set current Cobulin to " + currentID);
			break;
		case 2:
			currentID = id;
			Debug.Log ("Set current Cobulin to " + currentID);
			break;
		case 3:
			currentID = id;
			Debug.Log ("Set current Cobulin to " + currentID);
			break;
		default:
			break;
		}
	}

	void PlayDamage()
	{
		CobulinGameObject.gameObject.GetComponent<Animation>().Play ("Damage");
	}

	void SetToDead()
	{
		CobulinGameObject.GetComponent<Animation>().Play ("Dead");
	}
	
	#region IPunObservable implementation

//	void IPunObservable.OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
//	{
//		if (stream.isWriting)
//		{
//			stream.SendNext (health_1);
//			stream.SendNext (health_2);
//			stream.SendNext (health_3);
//		} else
//		{
//			this.health_1 = (float)stream.ReceiveNext ();
//			this.health_2 = (float)stream.ReceiveNext ();
//			this.health_3 = (float)stream.ReceiveNext ();
//		}
//	}
//
	#endregion
}
