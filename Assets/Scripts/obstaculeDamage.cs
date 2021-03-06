﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculeDamage : MonoBehaviour {
		public float damage;
		public float damageRate;
		public float pushBackForce;
		float nextDamage;
		bool playerInRange = false;
		GameObject thePlayer;
		GameObject thisObject;
		playerHealth thePlayerHealth;
	// Use this for initialization
	void Start () {
		nextDamage = Time.time;
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		thePlayerHealth = thePlayer.GetComponent<playerHealth>();
		thisObject = GameObject.FindGameObjectWithTag("Electric");
		InvokeRepeating("DisappearanceLogic",0,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(playerInRange){
			Attack();
		}
		//StartCoroutine(show());
		
	}
	
	/**IEnumerator show()
	{
		thisObject.SetActive(true);
		yield return new WaitForSeconds(1);
		thisObject.SetActive(false);
	}*/
	
	void DisappearanceLogic()
	{
		if(thisObject.activeSelf)
		{
			thisObject.SetActive(false);
		}else{
			thisObject.SetActive(true);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			playerInRange = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player"){
		playerInRange = false;
		}
	}
	void Attack() {
		if(nextDamage <= Time.time){
			thePlayerHealth.addDamage(damage);
			nextDamage = Time.time + damageRate;
			pushBack(thePlayer.transform);
		}
	}
	
	void pushBack(Transform pushedObject)
	{
		Vector3 pushDirection = new Vector3(0,(pushedObject.position.y - transform.position.y),0).normalized;
		pushDirection*= pushBackForce;
		Rigidbody pushedRB = pushedObject.GetComponent<Rigidbody>();
		pushedRB.velocity = Vector3.zero;
		pushedRB.AddForce(pushDirection,ForceMode.Impulse);
	}
}
