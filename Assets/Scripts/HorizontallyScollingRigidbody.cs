using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontallyScollingRigidbody : MonoBehaviour
{

    public float ScrollSpeed;
    public float SpeedMultiplier = 1f;
    public Direction ScrollDirection = Direction.Left;
    public enum Direction { Left, Right }
    private Rigidbody2D _rigidBody;

	// Use this for initialization
	void Start ()
	{
	    _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = new Vector2(GameController.Instance.GameSpeed * SpeedMultiplier * (ScrollDirection == Direction.Left ? -1f : 1f), 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
