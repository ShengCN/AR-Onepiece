﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : Photon.MonoBehaviour {
	private Animator animator;
	public float DirectionDampTime = .25f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		if (!animator)
		{
			Debug.LogError("PlayerAnimatorManager is Missing Animator Component",this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( photonView.isMine == false && PhotonNetwork.connected == true )
		{
			return;
		}

		if (!animator)
		{
			return;
		}

		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);          
		// only allow jumping if we are running.
		if (stateInfo.IsName("Base Layer.Run"))
		{
			// When using trigger parameter
			if (Input.GetButtonDown("Fire2")) animator.SetTrigger("Jump"); 
		}

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");


		if( v < 0 )
		{
			v = 0;
		}
		animator.SetFloat( "Speed", h*h+v*v );
		animator.SetFloat( "Direction", h, DirectionDampTime, Time.deltaTime );
	}
}
