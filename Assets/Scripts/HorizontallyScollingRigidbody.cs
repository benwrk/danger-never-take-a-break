using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontallyScollingRigidbody : MonoBehaviour
{

    public float ScrollSpeed = 0f;
    private Rigidbody2D _rigidBody;

	// Use this for initialization
	void Start ()
	{
	    _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = new Vector2(ScrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
