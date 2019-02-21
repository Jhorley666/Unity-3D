using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {


public float timeBetweenBullets = 0.15f;
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
		FlyingRobot myPlayer = transform.root.GetComponent<FlyingRobot>();
		if(Input.GetAxisRaw("Fire1")>0 && nextBullet<Time.time)
		{
				playASound(shootA);
				
				nextBullet = Time.time + timeBetweenBullets;
				Vector3 rot;
				if(myPlayer.GetRotation() == -1f){
					Debug.Log("Rotation: "+ myPlayer.GetRotation());
					rot = new Vector3(0,0,0);
				    Instantiate(projectile, transform.position, Quaternion.Euler(rot));
				}else{
					Debug.Log("Rotation: "+ myPlayer.GetRotation());
					rot = new Vector3(0,-180,0);		
					Instantiate(projectile, transform.position, Quaternion.Euler(rot));
				}	
			
			
		}
		
	}
	
	
	void playASound(AudioClip playTheSound){
		gunMuzzleAS.clip = playTheSound;
		gunMuzzleAS.Play();	
	}
}
