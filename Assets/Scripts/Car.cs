using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    private bool _isActive;
    private Animator _animator;

	// Use this for initialization
	void Start ()
	{
	    _isActive = true;
	    _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (_isActive)
	    {
	        if (Input.GetKey(KeyCode.W))
	        {
	            _animator.SetBool("IsAccelerating", true);
	        }
	        else
	        {
	            _animator.SetBool("IsAccelerating", false);
	        }
	    }
	}
}
