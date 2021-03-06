﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject player;
	public int totalGems = 0;
	public Text gemsText;

	public Transform currentCheckpoint;

	public Image fadePanel;

	public Image healthBar;
	public Text healthText;

	public GameObject gameOverPanel;

	public static LevelManager instance;

	void Awake(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}
	}

	void Start () {
		PlayerPrefs.DeleteAll ();
		totalGems = PlayerPrefs.GetInt ("coins");
		gemsText.text = ":" + totalGems.ToString ("00");
		fadePanel.gameObject.SetActive (true);
		fadePanel.CrossFadeAlpha (0, 2, true);
	}

	public void AddGem(){
		totalGems += 1;
		gemsText.text = ":" + totalGems.ToString ("00");
		PlayerPrefs.SetInt ("coins", totalGems);
	}

	public void RespawnPlayer(){
		StartCoroutine (Respawn());
		player.layer = LayerMask.NameToLayer("Player");
	}

	IEnumerator Respawn(){
		player.SetActive (false);
		fadePanel.color = Color.red;
		fadePanel.CrossFadeAlpha (1, 2, true);
		yield return new WaitForSeconds (2);
		player.transform.position = currentCheckpoint.position;
		player.SetActive (true);
		fadePanel.color = Color.black;
		fadePanel.CrossFadeAlpha (0, 2, true);
	}

	public void UpdateHealthBar(float amount, float maxHealth){
		healthBar.fillAmount = amount;
		healthText.text = (amount*maxHealth).ToString ();
	}

	public void GameOver(){
		gameOverPanel.SetActive (true);
	}
}
