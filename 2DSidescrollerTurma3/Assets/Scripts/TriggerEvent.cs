using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour {
	
	[Tooltip("Function called when trigger enter")]
	[SerializeField] // Serialize to show field in the editor
	public UnityEvent onTriggerEnter = new UnityEvent(); // our Unity Event

	[Tooltip("Should we remove this component after event is triggered?")]
	public bool destroyScriptWhenEventTriggered = false;
	bool isDestroyed = false;

	[Tooltip("Will the event trigger on collision?")]
	public bool triggeredOnCollision = true;

	void Start(){

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (triggeredOnCollision) {
				InvokeFunction ();
			}
		}
	}

	public void InvokeFunction(){
		onTriggerEnter.Invoke ();
		if (destroyScriptWhenEventTriggered) {
			isDestroyed = true;
			Destroy (GetComponent<TriggerEvent>());
		}
	}
}
