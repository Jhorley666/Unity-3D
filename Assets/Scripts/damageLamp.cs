using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageLamp : MonoBehaviour {
	public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="Enemy"){
			enemyHealth theEnemyHealth = other.GetComponent<enemyHealth>();
			if(theEnemyHealth !=null){
				theEnemyHealth.addDamage(damage);
			}
		}
	}
}
