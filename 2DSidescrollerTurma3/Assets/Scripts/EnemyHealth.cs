using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth = 100;
	public float currentHealth;

	public Image healthBar;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		UpdateHealthBar (currentHealth/maxHealth);
	}

	public void LoseHealth(float damage){
		currentHealth -= damage;
		UpdateHealthBar (currentHealth/maxHealth);
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	public void UpdateHealthBar(float amount){
		healthBar.fillAmount = amount;
	}
}
