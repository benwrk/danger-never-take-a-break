using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrigger : MonoBehaviour {

	// Use this for initialization
    private void Start () {
		
	}
	
	// Update is called once per frame
    private void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Car>() != null)
        {
            Debug.Log("Car hit!");
        }
    }

    //private void OnCollisionEnter2D(Collider2D other)
    //{
    //    Debug.Log("OBJ HIT!");
    //    if (other.GetComponent<Car>() != null)
    //    {
    //        Debug.Log("Car hit!");  
    //    }
    //}
}
