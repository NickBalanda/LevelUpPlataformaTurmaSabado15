using UnityEngine;
using System.Collections;

public class FollowEnemy : MonoBehaviour {
	private PlayerController thePlayer;
	public float moveSpeed;
	public float playerRange;

	float distance;
	bool startFollow = false;

	SpriteRenderer sr;

	void Start () {
		//Procura na hierarquia um objeto com esse componente
		thePlayer = FindObjectOfType<PlayerController> ();
		sr = GetComponent<SpriteRenderer>();
	}
	void Update () {
			distance = Vector2.Distance(transform.position,
				thePlayer.transform.position);
			
			if (distance < playerRange) {
				transform.position = Vector3.MoveTowards (transform.position, 
					thePlayer.transform.position, 
					moveSpeed * Time.deltaTime);
			}

		if (thePlayer.transform.position.x > transform.position.x) {
			sr.flipX = true;
		} else if (thePlayer.transform.position.x < transform.position.x) {
			sr.flipX = false;
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, playerRange);
	}

}
