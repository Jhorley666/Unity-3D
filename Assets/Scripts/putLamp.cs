using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class putLamp : MonoBehaviour {
	public float timeBetweenLamps = 0.30f;
	public Rigidbody lamp;
	public Transform barrelEnd;
	public Text counterLamp;
	float nextLamp;
	float numLamp = 10;
	
	void Start(){
		counterLamp.text = numLamp.ToString();
	}
	
	void Awake(){
		nextLamp = 0f;
	}
	
	void Update () {	
		if(Input.GetKeyDown(KeyCode.E) && nextLamp<Time.time && numLamp>0){
			
			Debug.Log("E pressed");
			nextLamp = Time.time + timeBetweenLamps;
			Rigidbody playerInstance;
			playerInstance = Instantiate(lamp, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
			playerInstance.AddForce(barrelEnd.forward * 10);
			numLamp--;
		}
				counterLamp.text = numLamp.ToString();
	}
	
	
}

