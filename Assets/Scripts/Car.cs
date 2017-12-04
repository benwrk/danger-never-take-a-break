﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Animator _animator;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.CarState == GameController.CState.Accelerating)
        {
            _animator.SetBool("IsAccelerating", true);
        }
        else
        {
            _animator.SetBool("IsAccelerating", false);
        }
    }
}