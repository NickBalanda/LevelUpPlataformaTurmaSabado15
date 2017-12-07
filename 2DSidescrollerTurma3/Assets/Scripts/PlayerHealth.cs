using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100;


	public float currentHealth;

	public float knockBackDuration = 1;
	public Vector2 knockBackPower;

	[HideInInspector]
	public bool knockBackRight;

	Rigidbody2D rb;
	SpriteRenderer sp;
	PlayerController pc;
	Animator anim;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sp = GetComponent<SpriteRenderer> ();
		pc = GetComponent<PlayerController> ();
		anim = GetComponent<Animator> ();

		currentHealth = maxHealth;
		LevelManager.instance.UpdateHealthBar (currentHealth/maxHealth,maxHealth);

	}
	public void GainHealth(float amount){
		currentHealth += amount;
		SoundManager.PlaySFX ("Special & Powerup (4)");
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		LevelManager.instance.UpdateHealthBar (currentHealth/maxHealth,maxHealth);
	}

	public void LoseHealth(float damage, bool knockback){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			LevelManager.instance.GameOver ();
		}
		LevelManager.instance.UpdateHealthBar (currentHealth/maxHealth,maxHealth);
		StartCoroutine (Invulnerable ());
		if (knockback) {
			StartCoroutine (Knockback ());
		}
	}

	public IEnumerator Knockback(){
		pc.stopPlayer = true;
		anim.SetBool("damage",true);
		if (knockBackRight) {
			rb.velocity = new Vector2 (-knockBackPower.x, knockBackPower.y);
		} else {
			rb.velocity = new Vector2 (knockBackPower.x, knockBackPower.y);
		}
	
		sp.color = Color.red;
		yield return new WaitForSeconds(knockBackDuration);
		sp.color = Color.white;
		pc.stopPlayer = false;
		anim.SetBool("damage",false);

	}

	public IEnumerator Invulnerable(){

		gameObject.layer = LayerMask.NameToLayer("Invulnerable");

		for(int i = 0; i<6;i++){
			yield return new WaitForSeconds (0.2f);
			sp.enabled = !sp.enabled;
		}
		gameObject.layer = LayerMask.NameToLayer("Player");
	}
}
