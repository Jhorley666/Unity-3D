using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRobot : MonoBehaviour {
	float flySpeed = 3f;
	// Use this for initialization

	
	void Start () {

	}
	
	
	// Update is called once per frame
	void Update () {
	float h = Input.GetAxis("Horizontal");
		float flyDelta = flySpeed * Time.deltaTime;
			Vector3 v3h = new Vector3(0,0,h * flyDelta);
			transform.Translate(v3h, Space.World);
			GetComponent<Animator>().SetFloat("speed",Mathf.Abs(h));
			
	if(h<0){
//		float direction = v <0 ? 0: -180f;
		transform.localRotation = Quaternion.Euler(-180,90,180);
	}
	if(h>0)
	{
		transform.localRotation = Quaternion.Euler(-180,-90,180);
	}	
	
	
	}
	
	
	public float GetRotation()
	{		
	if(transform.rotation.eulerAngles.y == 90)
		return -1;
	else
		return  1;
		
	}
	

	
	
	
}
