using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMove : MonoBehaviour {

	public float speed = 5;

	public bool facingRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	bool hittingWall;

	bool notAtEdge;
	public Transform edgeCheck;

	Rigidbody2D rb;
	Vector3 initScale;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		initScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, 
			wallCheckRadius, whatIsWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, 
			wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge) {
			facingRight = !facingRight;
		}

		if (facingRight) {
			transform.localScale = new Vector3 (-initScale.x, initScale.y, 
				initScale.z);
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		} else {
			transform.localScale = new Vector3 (initScale.x, initScale.y, 
				initScale.z);
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		}
	}
}
