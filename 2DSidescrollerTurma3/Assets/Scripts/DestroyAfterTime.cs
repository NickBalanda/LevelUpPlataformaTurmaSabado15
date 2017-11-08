using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	public int timeToDestroy = 3;

	void Start () {
		Destroy (gameObject, timeToDestroy);
	}

}
