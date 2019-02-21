using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {
	public float enemyMaxHealth;
	public float damageModifier;
	public GameObject damageParticles;
	public bool drops;
	public GameObject drop;
	public AudioClip deathSound;
	public float lampDamage;
	bool onLight;
	public bool canLight;
	float nextLight;
	float ligthInterval = 1f;
	float currentHealth;
	AudioSource enemyAS;
	Material enemyM;


	void Start () {
		currentHealth = enemyMaxHealth;
		enemyAS = GetComponent<AudioSource>();
		enemyM = GetComponent<Renderer>().material;
	}
	
	void Update () {
		if(onLight){
			addDamage(lampDamage);
			nextLight += ligthInterval;
		}
		if(onLight){
			onLight = false;
		}
	}
	
	public void addDamage(float damage){
		damage = damage * damageModifier;
		
		if(damage<=0)
			return;
			currentHealth -= damage;
			enemyAS.Play();
			enemyM.color = Color.red;
			Debug.Log(currentHealth);			
			if(currentHealth <=0) makeDead();
	}
	
	public void addLight()
	{
		if(!canLight) return;
		onLight = true;
		nextLight = Time.time + ligthInterval;
	}
	void makeDead(){
		AudioSource.PlayClipAtPoint(deathSound,transform.position,0.15f);
		Destroy(gameObject.transform.root.gameObject);
		if(drops) Instantiate(drop, transform.position, transform.rotation);
	}
	
	
}
