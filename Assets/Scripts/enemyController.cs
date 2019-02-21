using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	float startMove;
	public float moveSpeed;
	bool detected;
	GameObject theEnemy;
	fireEnemy fire;
	void Start () {
		detected = false;
		theEnemy = GameObject.FindGameObjectWithTag("Enemy");
		fire = theEnemy.GetComponent<fireEnemy>();
	}
	
	void Update () {
		if(detected == true){
			startMove = moveSpeed * Time.deltaTime;
			Vector3 v3h = new Vector3(0,0,-startMove);
			transform.Translate(v3h,Space.World);
			fire.playerDetected(detected);
		}
	}
	
	void OnTriggerEnter(Collider other){

		
		if(other.tag == "Player" && !detected){
			detected = true;
			moveSpeed = 2;	
			Debug.Log("Player Enter");
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.tag == "Player" && detected){
			moveSpeed = 0;
			detected  = false;
			Debug.Log("Player Exit");
		}
	}
	
}
