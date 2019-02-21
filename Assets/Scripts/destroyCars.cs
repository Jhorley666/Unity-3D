using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyCars : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.z >= 20)
        {
            Destruction();
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "destroyer")
        {
            Destruction();
        }
    }

    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
