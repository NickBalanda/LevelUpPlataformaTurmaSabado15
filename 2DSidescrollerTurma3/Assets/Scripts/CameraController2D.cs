using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2D : MonoBehaviour {
	public Transform target;
	public float smoothSpeed = 10f;
	public Vector3 offset;

	public float minX, maxX, minY, maxY;

	void LateUpdate () {

		Vector3 desiredPosition =  target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, 
												desiredPosition, 
												smoothSpeed * Time.deltaTime);

		transform.position = smoothedPosition;
		transform.position = new Vector3 (Mathf.Clamp(transform.position.x,
										  minX, maxX), 
								Mathf.Clamp (transform.position.y, minY, maxY), 
								transform.position.z);
	}

}
