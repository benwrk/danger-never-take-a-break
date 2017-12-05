﻿using UnityEngine;

namespace UI
{
    public class TimerGauge : MonoBehaviour {

        private float _originalX;
        // Use this for initialization
        private void Start()
        {
            _originalX = transform.localScale.x;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.localScale = new Vector3(_originalX * (GameController.Instance.TimeLeftToAnswer / GameController.Instance.QuestionTime), transform.localScale.y, transform.localScale.z);
        }
    }
}
