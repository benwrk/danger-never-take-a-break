﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OBJ HIT!");
        if (other.GetComponent<Car>() != null)
        {
            Debug.Log("Car hit!");  
        }
    }
}
