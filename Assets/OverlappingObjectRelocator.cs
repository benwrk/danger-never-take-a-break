using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlappingObjectRelocator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Decoration"))
        {
            transform.position = new Vector3(transform.position.x + Random.Range(1f, 2f), transform.position.y, transform.position.z);
            Debug.Log("Collide!");
        }
    }
}
