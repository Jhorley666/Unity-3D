using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPointLightPlayer : MonoBehaviour {
	public Transform target;
	public float smothSpeed = 0.125f;
	public Vector3 offset;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 diseredPosition = target.position + offset;
		Vector3 smothedPosition  = Vector3.Lerp(transform.position, diseredPosition, smothSpeed);
		transform.position = smothedPosition;
	}
}
