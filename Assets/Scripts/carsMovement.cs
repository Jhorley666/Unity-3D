﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carsMovement : MonoBehaviour {
    public float speed = 4f;
	// Use this for initialization
	void Start () {
     	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f,speed * Time.deltaTime);
    }
}
