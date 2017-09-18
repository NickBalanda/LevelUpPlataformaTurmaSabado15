using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour {

	public float damage;
	public bool knockback = true;

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			
			PlayerHealth player = other.GetComponent<PlayerHealth> ();

			if (transform.position.x > player.gameObject.transform.position.x) {
				player.knockBackRight = true;
			} else {
				player.knockBackRight = false;
			}

			player.LoseHealth (damage,knockback);
		}
	}
}
