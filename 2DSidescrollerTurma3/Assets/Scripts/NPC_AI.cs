using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AI : MonoBehaviour {
	
	public float walkSpeed;

	public float walkTime;
	float walkCounter;

	public float waitTime;
	float waitCounter;

	public bool isWalking;

	public bool facingRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	bool hittingWall;

	Vector3 initScale;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		waitCounter = waitTime;
		walkCounter = walkTime;

		initScale = transform.localScale;

		ChooseDirection ();
	}
	
	// Update is called once per frame
	void Update () {
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall) {
			facingRight = !facingRight;
		}

		if (isWalking) {
			walkCounter -= Time.deltaTime;
			if (walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}
			if (facingRight) {
				transform.localScale = new Vector3 (initScale.x, initScale.y, initScale.z);
				rb.velocity = new Vector2 (walkSpeed, rb.velocity.y);
			} else {
				transform.localScale = new Vector3 (-initScale.x, initScale.y, initScale.z);
				rb.velocity = new Vector2 (-walkSpeed, rb.velocity.y);
			}
		} 

		else {

			rb.velocity = Vector2.zero;

			waitCounter -= Time.deltaTime;
			if (waitCounter < 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection(){
		int walkDirection = Random.Range (0, 2);

		if (walkDirection == 0) {
			facingRight = true;
		} else {
			facingRight = false;
		}

		isWalking = true;
		walkCounter = walkTime;
	}
}
