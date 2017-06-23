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
using System.Runtime.InteropServices;

namespace ExitGames.Demos.DemoAnimator
{
	public class TestLocation : Photon.MonoBehaviour 
	{
		#region PUBLIC PROPERTIES

		public float DirectionDampTime = 0.25f;
		public float speed = 10f;

		#endregion

		#region PRIVATE PROPERTIES

		Animator animator;

		#endregion

		#region MONOBEHAVIOUR MESSAGES

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
		void Start () 
		{
			animator = GetComponent<Animator>();
		}

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
		void Update () 
		{

			testFunc ();

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

			// deal with movement
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			float v = CrossPlatformInputManager.GetAxis("Vertical");

			h += Input.GetAxis("Horizontal");
			v += Input.GetAxis("Vertical");

			// prevent negative Speed.
			if( v < 0 )
			{
				v = 0;
			}

			// set the Animator Parameters
			animator.SetFloat( "Speed", h*h+v*v );
			animator.SetFloat( "Direction", h, DirectionDampTime, Time.deltaTime );

			//			changeRotation ();
		}

		#endregion


		void changeRotation()
		{
			Debug.Log ("Begin Rotation detection!********************");

			Vector3 direction = Vector3.zero;
			direction.x = -Input.acceleration.y;
			direction.z = -Input.acceleration.x;

			//			if (direction.sqrMagnitude > 1)
			//			{
			//				direction.Normalize ();
			//			}

			direction *= Time.deltaTime;
			var offsetX = direction.x * speed;
			var offSetZ = direction.z * speed;
			var rotation = new Quaternion(offsetX,0f,offSetZ,0f);

			Debug.Log ("Direction: "+ rotation);
			transform.rotation = rotation;
		}

		[DllImport("__Internal")]
		private static extern void testFunc ();
	}
}