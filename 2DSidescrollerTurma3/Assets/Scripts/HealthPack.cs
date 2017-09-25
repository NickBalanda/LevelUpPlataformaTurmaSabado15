using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

	public float amount;

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){

			PlayerHealth player = other.GetComponent<PlayerHealth> ();
			player.GainHealth (amount);
			Destroy (gameObject);
		}
	}
}
