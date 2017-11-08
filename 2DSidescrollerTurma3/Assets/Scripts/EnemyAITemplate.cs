using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAITemplate : MonoBehaviour {

    public enum EnemyState {IDLE = 0, DOG = 1, EAGLE = 2}

    public EnemyState states;

    void Awake() {
        states = EnemyState.IDLE;
    }
    void Start () {
        StartCoroutine(EnemySM());
	}

    IEnumerator EnemySM() {
        while (true) {
            yield return StartCoroutine(states.ToString());
        }
    }

	IEnumerator IDLE() {
        //Entrou no estado de STATE1
		GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("Estou esperando");
		yield return new WaitForSeconds(3.0f);
		states = (EnemyState)Random.Range(0, System.Enum.GetValues(typeof(EnemyState)).Length);

    }

    IEnumerator DOG() {
        //Entrou no estado de STATE2
        Debug.Log("DOG MODE ON!");
		GetComponent<SpriteRenderer>().color = Color.green;
        //Executou o estado de STATE2
        while (states == EnemyState.DOG) {
			Debug.Log ("I'm still a Dog");
            yield return new WaitForSeconds(3.0f);
			states = EnemyState.EAGLE;
        }
  
    }

    IEnumerator EAGLE() {
        //Entrou no estado de STATE3
        Debug.Log("EAGLE MODE ON!");

        //Executou o estado de STATE3
        while (states == EnemyState.EAGLE) {
            yield return new WaitForSeconds(2.0f);
			states = EnemyState.IDLE;
        }

    }
}
