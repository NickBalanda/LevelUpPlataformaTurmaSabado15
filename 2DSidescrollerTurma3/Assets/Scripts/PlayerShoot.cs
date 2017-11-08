using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public GameObject projectile;
	public Transform shootPosition;

	PlayerController pc;
	void Start () {
		pc = GetComponent<PlayerController> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Shoot")){
			GameObject obj = (GameObject)Instantiate (projectile,shootPosition.position,Quaternion.identity);
			if (!pc.facingRight) {
				obj.GetComponent<Projectile> ().speed *= -1;
			}
		}
	}
}
