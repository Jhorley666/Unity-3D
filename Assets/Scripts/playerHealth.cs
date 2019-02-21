using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class playerHealth : MonoBehaviour {
	public float fallHealth;
	float currentHealth;
	
	public GameObject playerDeathFX;
	//UI
	public Slider playerHealthSlider;
	public Image damageScreen;
		Color flashColor = new Color(255f,255f,255f,1f);
		float flashSpeed  = 5f;
		bool damaged = false;
	//audio
		AudioSource playerAS;
	public AudioClip deadSound;	
	void Start () {
		currentHealth = fallHealth;
		playerHealthSlider.maxValue = fallHealth;
		playerHealthSlider.value = currentHealth;
		
		playerAS = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		if(damaged)
		{
			damageScreen.color  = flashColor;
		}else{
			damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, flashSpeed*Time.deltaTime);
		
		}
			damaged = false;
	}
	
	public void addDamage(float damage){
		currentHealth -= damage;
		playerHealthSlider.value = currentHealth;
		damaged = true;
		playerAS.Play();
		if(currentHealth <= 0){
			
			makeDead();
		}
	}
	
	public void addHealth(float health)
	{
		currentHealth += health;
		if(currentHealth>fallHealth)
			currentHealth = fallHealth;
		playerHealthSlider.value = currentHealth;
	}
	
	public void makeDead()
	{
		Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
		damageScreen.color  = flashColor;
		AudioSource.PlayClipAtPoint(deadSound, transform.position,1f);
		Destroy(gameObject);
		
	}
}
