using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class WalkingOrc : Photon.MonoBehaviour 
{

	private Animator animator;

	public float walkspeed = 5;
	private float horizontal;
	private float vertical;
	private bool isAttacking = false;
	private CharacterController character;

	public GameObject gamecam;
	public Vector2 camPosition;
	private bool dead;


	public GameObject[] characters;
	public int currentChar = 0;
	public float h;
	public float v;
	public float speed;
	private float xCache;
	private float yCache;
	public bool isDebug = true;

	// For rotation
	private float newY;
	private float oldY;
	private float dY;
//	private float ratio = 38f / 9f;
	private float ratio = 7f;

	void Start()
	{
//		this.GetComponent<PhotonView>().RPC("RPC_SetCharacter", PhotonTargets.All,1);
		character = GetComponent<CharacterController> ();
		setCharacter (1);

		xCache = getX ();
		yCache = getY ();
		speed = 18.5f;
		Debug.Log ("Current X: " + xCache + " Y: " + yCache);
	}

	void FixedUpdate()
	{
		// Prevent control is connected to Photon and represent the localPlayer
		if( photonView.isMine == false && PhotonNetwork.connected == true )
		{
			return;
		}

	}

	void Update()
	{
		// Prevent control is connected to Photon and represent the localPlayer
		if( photonView.isMine == false && PhotonNetwork.connected == true )
		{
			return;
		}

		if (!dead)
		{
			// move camera
			if (gamecam)
				gamecam.transform.position = transform.position + new Vector3(0, camPosition.x, -camPosition.y);

			// attack
			if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump") && !isAttacking)
			{
				isAttacking = true;
				//animator.Play("Attack");
				animator.SetTrigger("Attack");
				StartCoroutine(stopAttack(1));
				activateTrails(true);
			}

			animator.SetBool("isAttacking", isAttacking);

			//switch character
			if (Input.GetKeyDown("left"))
			{
//				setCharacter(-1);
				this.GetComponent<PhotonView>().RPC("RPC_SetCharacter", PhotonTargets.All,1);
				isAttacking = true;
				StartCoroutine(stopAttack(1f));
			}

			if (Input.GetKeyDown("right"))
			{
				this.GetComponent<PhotonView>().RPC("RPC_SetCharacter", PhotonTargets.All,1);
				isAttacking = true;
				StartCoroutine(stopAttack(1f));
			}

			if (animator && !dead)
			{
				CheckSwitchPlayer ();

				//walk
				horizontal = Input.GetAxis ("Horizontal");
				vertical = Input.GetAxis ("Vertical");

				AnimationMove (horizontal, vertical);
				if (!transform.localPosition.y.AlmostEquals (5.4f, 0.1f))
				{
					var tmpPos = transform.localPosition;
					tmpPos.y = 5.4f;
					transform.localPosition = tmpPos;
				}

				// For Debug
				if (Input.anyKey && !ExitGames.Demos.DemoAnimator.GameManager.isARCounting)
				{
					 
					AnimationMove (0f, 0.02f);
				}

				// Bluetooth motion module
				// Get changed Movement
				float tmp = getX ();
				float xChanged = tmp - xCache;
				xCache = tmp;
				tmp = getY ();
				float yChanged = tmp - yCache;
				yCache = tmp;
				Vector2 tmpMovement = new Vector2 (xChanged, yChanged);
				Vector2 minimunMovement = new Vector2 (0.2f, 0.01f);
				if (tmpMovement.magnitude < minimunMovement.magnitude)
				{
					return;
				}

				AnimationMove (0f, tmpMovement.magnitude);
				if (!xChanged.AlmostEquals (0f, 0.001f) && !yChanged.AlmostEquals (0f, 0.001F))
					Debug.Log ("Changed X: " + xChanged + " Y: " + yChanged);
			}
		}

	}

	public IEnumerator stopAttack(float lenght)
	{
		yield return new WaitForSeconds(lenght); // attack lenght
		isAttacking = false;
		activateTrails(false);
	}

	public IEnumerator selfdestruct()
	{
		animator.SetTrigger("isDead");
		dead = true;

		yield return new WaitForSeconds(1.3f);
		GameObject.FindWithTag("GameController").GetComponent<gameContoller>().resetLevel();
	}

	public void setCharacter(int i)
	{
	
		currentChar += i;

		if (currentChar > characters.Length - 1)
			currentChar = 0;
		if (currentChar < 0)
			currentChar = characters.Length - 1;

		foreach (GameObject child in characters)
		{
			if (child == characters[currentChar])
				child.SetActive(true);
			else
			{
				child.SetActive(false);

				if (child.GetComponent<triggerProjectile>())
					child.GetComponent<triggerProjectile>().clearProjectiles();
			}
		}
		animator = GetComponentInChildren<Animator>();

	}

	public void activateTrails(bool state)
	{
		var tails = GetComponentsInChildren<TrailRenderer>();
		foreach (TrailRenderer tt in tails)
		{
			tt.enabled = state;
		}
	}

	/// <summary>
	/// Animations the move.
	/// </summary>
	/// <param name="x">The x coordinate that character moves.</param>
	/// <param name="y">The y coordinate that character moves.</param>
	void AnimationMove(float x, float y)
	{
		if (x.AlmostEquals (0f,0.0001f) && y.AlmostEquals (0f,0.0001f))
		{
			animator.SetFloat ("Speed",0f);
			return;
		}


		Vector3 move = new Vector3 (x*ratio, 0f, y*ratio);
		move = transform.TransformDirection (move);

		animator.SetFloat ("Speed", 100f);
		character.Move (move);
	}

	void CheckSwitchPlayer()
	{
		newY = Input.acceleration.y;
		dY = newY - oldY;
		oldY = newY;

		if (dY > 1.5f || dY < -1.5f)
		{
			Debug.Log ("Happened Switch!");
			Handheld.Vibrate ();
			// Switch
			this.GetComponent<PhotonView>().RPC("RPC_SetCharacter", PhotonTargets.All,1);

		}
	}

	[PunRPC]
	void RPC_SetCharacter(int i)
	{
		setCharacter (i);
	}

	// Blue Tooth extern functions
	[DllImport("__Internal")]
	private static extern float getX ();
	[DllImport("__Internal")]
	private static extern float getY ();
}
