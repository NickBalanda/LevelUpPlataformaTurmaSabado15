using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour {
	
	[SerializeField]
	public UnityEvent onDeath = new UnityEvent();
	//onDeath.Invoke();

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
			onDeath.Invoke ();
			Destroy (gameObject);
		}
	}

	public void UpdateHealthBar(float amount){
		healthBar.fillAmount = amount;
	}
}
