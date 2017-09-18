using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Player Movement")]
	public float moveSpeed = 5;
	float currentSpeed;
	public bool facingRight = true;

	[Header("Player Jump")]
	public float jumpHeight = 10;
	public Transform groundCheck;
	public float groundCheckRadius = 0.2f;
	public LayerMask whatIsGround;
	public bool grounded;
	public bool doubleJumpAvailable = false;

	[HideInInspector]
	public bool stopPlayer = false;

	Rigidbody2D rb;
	Animator anim;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		currentSpeed = moveSpeed;
	}

	void OnEnabled(){
		gameObject.layer = LayerMask.NameToLayer("Player");
		stopPlayer = false;
	}

	void Update () {

		grounded = Physics2D.OverlapCircle(groundCheck.position,
											groundCheckRadius,
											whatIsGround);
		anim.SetBool ("grounded", grounded);

		float move = Input.GetAxis("Horizontal");

		if (stopPlayer == false) {
			rb.velocity = new Vector2 (move * currentSpeed, rb.velocity.y);
		}

		anim.SetFloat ("speed", Mathf.Abs(move));
		//Check for Flip
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip();
		}

		//Jump
		if (Input.GetButtonDown ("Jump") && grounded) {
			Jump ();
		} else if (Input.GetButtonDown ("Jump") && doubleJumpAvailable) {
			Jump ();
			doubleJumpAvailable = false;
		}
	}

	public void Jump(){
		rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
		doubleJumpAvailable = true;
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theFlip = new Vector3 (transform.eulerAngles.x, 
										transform.eulerAngles.y + 180, 
										transform.eulerAngles.z);
		transform.eulerAngles = theFlip;
	}

}
