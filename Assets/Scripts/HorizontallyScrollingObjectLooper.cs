using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontallyScrollingObjectLooper : MonoBehaviour
{
    private float _length;

    // Use this for initialization

    // Update is called once per frame

    void Start()
    {
    }

    void Update()
    {
        _length = GetComponent<SpriteRenderer>().size.x + Utility.GetEffectiveScaling(transform).x;
        //Debug.Log(transform.position.x + " --- " + _length);
        if (transform.position.x < -_length)
        {
            transform.position = (Vector2)transform.position + new Vector2(_length * 2f, 0f);
        }
    }
}