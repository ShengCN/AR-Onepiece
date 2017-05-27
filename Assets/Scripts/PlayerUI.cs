using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public Text playerNameText;
	public Text playerScoreText;

	PlayerManager _target;
	public Vector3 ScreenOffset = new Vector3(0f,30f,0f);
	float _characterControllerHeight = 0f;
	Transform _targetTransfrom;
	Vector3 _targetPosition;


	void Awake()
	{
		this.GetComponent<Transform> ().SetParent (GameObject.Find ("Canvas").GetComponent<Transform> ());
	}

	void Update()
	{
		if (playerScoreText != null)
		{
			playerScoreText.text = _target.currentScore.ToString();
		}

		if (_target == null)
		{
			Destroy (this.gameObject);
			return;
		}
	}

	void LateUpdate()
	{
		if (_targetTransfrom != null)
		{
			_targetPosition = _targetTransfrom.position;
			_targetPosition.y += _characterControllerHeight;
			this.transform.transform.position = Camera.main.WorldToScreenPoint (_targetPosition) + ScreenOffset;
		}
	}

	public void SetTarget(PlayerManager target)
	{
		if (target == null)
		{
			Debug.LogError ("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
			return;
		}

		_target = target;
		_targetTransfrom = target.transform;
		CharacterController _characterController = _target.GetComponent<CharacterController> ();
		if (_characterController != null)
		{
			_characterControllerHeight = _characterController.height;
		}

		if (playerNameText != null)
		{
			playerNameText.text = _target.photonView.owner.NickName;
		}
	}
}
