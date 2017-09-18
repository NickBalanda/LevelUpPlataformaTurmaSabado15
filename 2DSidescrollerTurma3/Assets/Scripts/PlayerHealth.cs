using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100;

	[HideInInspector]
	public float currentHealth;

	public float knockBackDuration = 1;
	public Vector2 knockBackPower;

	[HideInInspector]
	public bool knockBackRight;

	Rigidbody2D rb;
	SpriteRenderer sp;
	PlayerController pc;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sp = GetComponent<SpriteRenderer> ();
		pc = GetComponent<PlayerController> ();

		currentHealth = maxHealth;
	}
	
	public void LoseHealth(float damage, bool knockback){
		currentHealth -= damage;
		StartCoroutine (Invulnerable ());

		if (knockback) {
			StartCoroutine (Knockback ());
		}
	}

	public IEnumerator Knockback(){
		pc.stopPlayer = true;

		if (knockBackRight) {
			rb.velocity = new Vector2 (-knockBackPower.x, knockBackPower.y);
		} else {
			rb.velocity = new Vector2 (knockBackPower.x, knockBackPower.y);
		}
	
		yield return new WaitForSeconds(knockBackDuration);
		pc.stopPlayer = false;
	}

	public IEnumerator Invulnerable(){

		gameObject.layer = LayerMask.NameToLayer("Invulnerable");

		sp.color = Color.red;
		yield return new WaitForSeconds(0.3f);
		sp.color = Color.white;

		for(int i = 0; i<6;i++){
			yield return new WaitForSeconds (0.2f);
			sp.enabled = !sp.enabled;
		}

		gameObject.layer = LayerMask.NameToLayer("Player");
	}
}
