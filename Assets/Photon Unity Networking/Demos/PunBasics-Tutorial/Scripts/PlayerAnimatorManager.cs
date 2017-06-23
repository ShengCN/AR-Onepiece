// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerAnimatorManager.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in DemoAnimator to cdeal with the networked player Animator Component controls.
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------


using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace ExitGames.Demos.DemoAnimator
{
	public class PlayerAnimatorManager : Photon.MonoBehaviour 
	{
		#region PUBLIC PROPERTIES

		public float DirectionDampTime = 0.25f;
		public float speed = 1f;
		public float h ;
		public float v;

		#endregion

		#region PRIVATE PROPERTIES

		Animator animator;
		CharacterController character;

		#endregion

		#region MONOBEHAVIOUR MESSAGES

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
	    void Start () 
	    {
	        animator = GetComponent<Animator>();
			character = GetComponent<CharacterController> ();

			h = 0.0f;
			v = 0.25f;
	    }
	        
		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
	    void Update () 
	    {
			// Prevent control is connected to Photon and represent the localPlayer
	        if( photonView.isMine == false && PhotonNetwork.connected == true )
	        {
	            return;
	        }

			// failSafe is missing Animator component on GameObject
	        if (!animator)
	        {
				return;
			}

			// deal with Jumping
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);			

			// only allow jumping if we are running.
            if (stateInfo.IsName("Base Layer.Run"))
            {
				// When using trigger parameter
                if (Input.GetButtonDown("Fire2")) animator.SetTrigger("Jump"); 
			}
           
			// Deal with movement
//            float h =  CrossPlatformInputManager.GetAxis("Horizontal");
//			float v = CrossPlatformInputManager.GetAxis("Vertical");
			// Using  GPS
//			float h = GPSLocation.altitudeChanged;
//			float v = GPSLocation.latitudeChanged;
//			float h = 0.1f;
//			float v = 0.1f;
			if (Input.anyKey)
			{
				Debug.Log ("Any key pressed");
				AnimationMove (h, v);
			} else
			{
				AnimationMove (0f, 0f);
			}
	    }

		#endregion

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


			Vector3 move = new Vector3 (x*speed, 0f, y*speed);
			//		move = transform.TransformDirection (move);

			character.transform.LookAt (transform.position + move);


			animator.SetFloat ("Speed",move.magnitude);
//			character.Move (move);
		}

	}
}