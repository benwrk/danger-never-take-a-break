using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScrollLooper : MonoBehaviour
{
    void Update()
    {
        float length = GetComponent<SpriteRenderer>().bounds.size.x;
        if (transform.position.x < -length)
        {
            transform.position = (Vector2) transform.position + new Vector2(length * 2f, 0f);
        }
    }
}