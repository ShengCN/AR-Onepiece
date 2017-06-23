using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementManager : MonoBehaviour {
	private CharacterController character;
	private Animator animator;
	public float x = 1f;
	public float y = 1f;
	public Text gpsText;
	public Text changedGpsText;
	public Text degreeText;
	public float DirectionDampTime = 0.5f;

	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController> ();		
		animator = GetComponent<Animator> ();

		LogHelper.LogError (character);
		LogHelper.LogError (animator);
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis ("Horizontal");
		y = Input.GetAxis ("Vertical");

		AnimationMove (x,y);
	}


	/// <summary>
	/// Animations the move.
	/// </summary>
	/// <param name="x">The x coordinate that character moves.</param>
	/// <param name="y">The y coordinate that character moves.</param>
	void AnimationMove(float x, float y)
	{
		if (x.AlmostEquals (0f,0.01f) && y.AlmostEquals (0f,0.01f))
		{
			animator.SetFloat ("Speed",0f);
			return;
		}


		Vector3 move = new Vector3 (x, 0f, y);
//		move = transform.TransformDirection (move);
		var degree = Vector3.Angle (transform.forward, move);

		character.transform.LookAt (transform.position + move);


		animator.SetFloat ("Speed",1f);
		character.Move (move);

		gpsText.text = transform.position.ToString();
		changedGpsText.text = move.ToString();
		degreeText.text = degree.ToString ();
	}
}
