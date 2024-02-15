using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public Animator playerAnimator;

	//Movement Variables
	public float speed;
	public float maxSpeed;
	public float speedJump;
	public float maxSpeedjump;
	private Rigidbody2D rigidbodyPlayer;

	private bool lookToRight = true;
	private Vector3 positionRight;
	private Vector3 positionLeft;


	// Use this for initialization
	void Start () {

		rigidbodyPlayer = GetComponent<Rigidbody2D> ();
		positionRight = playerAnimator.transform.localScale;
		positionLeft = positionRight;
		positionLeft.x *= -1;
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 inputDirection = new Vector2 (Input.GetAxis ("Horizontal")*speed, 0);

		if (inputDirection.x > 0) {
			lookToRight = true;
		}
		if (inputDirection.x < 0) {
			lookToRight = false;
		}

		if (lookToRight) {
			playerAnimator.transform.localScale = positionRight;
		} else {
			playerAnimator.transform.localScale = positionLeft;
		}


		rigidbodyPlayer.velocity = new Vector2(inputDirection.x, rigidbodyPlayer.velocity.y);

		if (rigidbodyPlayer.velocity.x > maxSpeed) {
			rigidbodyPlayer.velocity = new Vector2 (maxSpeed, rigidbodyPlayer.velocity.y);
		}

		if (rigidbodyPlayer.velocity.x < -maxSpeed) {
			rigidbodyPlayer.velocity = new Vector2 (-maxSpeed, rigidbodyPlayer.velocity.y);
		}

		playerAnimator.SetFloat("velocity",Mathf.Abs(inputDirection.x));

	}
}
