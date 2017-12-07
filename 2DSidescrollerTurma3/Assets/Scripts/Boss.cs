using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public enum EnemyState {STATE1 = 0, STATE2 = 1, STATE3 = 2}

	[Tooltip("current Enemy state")]
	public EnemyState states;

	public float speed = 7;
	float initSpeed;

	public bool facingRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	bool hittingWall;

	public Transform eagleTarget;

	public GameObject projectile;
	public Transform shootPosition;
	public int numOfProjectiles = 5;

	Vector3 lastPosition;
	Vector3 initScale;
	Rigidbody2D rb;
	Animator anim;

	void Awake() {
		states = EnemyState.STATE1;

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		initScale = transform.localScale;
		initSpeed = speed;
	}
	void Start () {
		//StartEnemy ();
	}

	public void StartEnemy(){
		StartCoroutine(EnemySM());
	}

	IEnumerator EnemySM() {
		while (true) {
			yield return StartCoroutine(states.ToString());
		}
	}

	IEnumerator STATE1() {
		//Entrou no estado de IDLE
		Debug.Log("STATE1");
		anim.Play ("Idle");
		//Executou o estado de STATE1
		while (states == EnemyState.STATE1) {
			yield return new WaitForSeconds(3.0f);
			states = (EnemyState)Random.Range(1, System.Enum.GetValues(typeof(EnemyState)).Length);
		}

	}

	IEnumerator STATE2() {
		//Entrou no estado de CACHORRO
		Debug.Log("STATE2");
		anim.Play ("DogForm");
		speed = initSpeed;
		//Executou o estado de STATE2
		while (states == EnemyState.STATE2) {
			yield return new WaitForSeconds(0.0f);

			if (hittingWall) {
				facingRight = !facingRight;
				speed = 0;
				states = EnemyState.STATE1;
			}

			if (facingRight) {
				transform.localScale = new Vector3 (-initScale.x, initScale.y, 
					initScale.z);
				rb.velocity = new Vector2 (speed, rb.velocity.y);
			} else {
				transform.localScale = new Vector3 (initScale.x, initScale.y, 
					initScale.z);
				rb.velocity = new Vector2 (-speed, rb.velocity.y);
			}
		}

	}

	IEnumerator STATE3() {
		//Entrou no estado de AGUIA
		Debug.Log("STATE3");
		anim.Play ("EagleForm");
		rb.gravityScale = 0;
		//Executou o estado de STATE3
		while (states == EnemyState.STATE3) {

			lastPosition = transform.position;
			transform.position = eagleTarget.position;
			Shoot ();
			yield return new WaitForSeconds(3.0f);
			transform.position = lastPosition;
			rb.gravityScale = 2;
			states = EnemyState.STATE1;

		}

	}

	void Update () {
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, 
			wallCheckRadius, whatIsWall);

	}

	public void Shoot(){
		for (int i = 0; i < numOfProjectiles; i++) {
			shootPosition.eulerAngles = new Vector3(shootPosition.eulerAngles.x,shootPosition.eulerAngles.y,Random.Range(-70,70));
			Instantiate (projectile, shootPosition.position, shootPosition.rotation);
		}
	}
}
