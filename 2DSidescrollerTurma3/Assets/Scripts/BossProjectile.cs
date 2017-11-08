using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour {

	public float speed;
	public float damage;
	public GameObject explosion;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject,4);
	}

	// Update is called once per frame
	void FixedUpdate () {
		rb.MovePosition(transform.position + (-transform.up) * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		Instantiate (explosion, transform.position, Quaternion.identity);
		if (other.gameObject.tag == "Player") {
			other.GetComponent<PlayerHealth>().LoseHealth(damage,true);
		}

	}

}
