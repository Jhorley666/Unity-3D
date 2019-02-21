using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAparence : MonoBehaviour {
	public Material[] enemyMaterials;
	// Use this for initialization
	void Start () {
		SkinnedMeshRenderer myRenderer = GetComponent<SkinnedMeshRenderer>();
		myRenderer.material = enemyMaterials[Random.Range(0,enemyMaterials.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
