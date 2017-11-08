using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float speed;
	public float damage;
	public GameObject explosion;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 4);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (speed, rb.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		Instantiate (explosion, transform.position, Quaternion.identity);
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<EnemyHealth>().LoseHealth (damage);
		}
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D other){
		Instantiate (explosion, transform.position, Quaternion.identity);
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealth>().LoseHealth (damage);
		}
		Destroy (gameObject);
	}
}
