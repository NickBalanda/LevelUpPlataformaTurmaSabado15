﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			SoundManager.PlaySFX ("Coin");
			LevelManager.instance.AddGem ();
			gameObject.SetActive (false);
		}
	}
}
