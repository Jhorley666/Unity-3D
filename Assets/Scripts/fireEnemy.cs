using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireEnemy : MonoBehaviour {
	public float timeBetweenBullets = 5f;
	public GameObject projectile;
	float nextBullet;
	AudioSource gunMuzzleAS;
	public AudioClip shootA;
	void Awake () {
		nextBullet = 0f;
		gunMuzzleAS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public void playerDetected(bool detected){
		
		if(detected == true && nextBullet<Time.time){
			    playASound(shootA);
				nextBullet = Time.time + timeBetweenBullets;
				Vector3 rot;
				rot = new Vector3(0,-180,0);
				Instantiate(projectile, transform.position, Quaternion.Euler(rot));
		}
		
	}
	
	void playASound(AudioClip playTheSound){
		gunMuzzleAS.clip = playTheSound;
		gunMuzzleAS.Play();	
	}
}
