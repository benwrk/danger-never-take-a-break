using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScroller : MonoBehaviour
{
    public float SpeedMultiplier = 1f;
    private Rigidbody2D _rigidBody;

	// Use this for initialization
	void Start ()
	{
	    _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = new Vector2(GameController.Instance.GameSpeed * SpeedMultiplier, 0);
	}
}
