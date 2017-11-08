using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	
	PlayerController pc;
	void Start () {
		pc = GetComponentInParent<PlayerController> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
			pc.Jump ();
		}
	}

}
