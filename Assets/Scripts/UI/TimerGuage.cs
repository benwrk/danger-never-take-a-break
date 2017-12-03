using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGuage : MonoBehaviour
{
    private float _originalX;
    // Use this for initialization
    void Start()
    {
        _originalX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(_originalX * (GameController.Instance.TimeLeft / GameController.GameTime), transform.localScale.y, transform.localScale.z);
        Debug.Log(_originalX + " | " + transform.localScale);
    }
}
