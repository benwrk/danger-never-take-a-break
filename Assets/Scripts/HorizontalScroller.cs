using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScroller : MonoBehaviour
{
    public float SpeedMultiplier = 1f;
    private Rigidbody2D _rigidBody;
    private Vector2 _scrollVelocityVector;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _scrollVelocityVector = new Vector2(GameController.Instance.GameSpeed * SpeedMultiplier, 0);
    }

    void Update()
    {
        _rigidBody.velocity = GameController.Instance.State == GameController.GameState.Active ? _scrollVelocityVector : Vector2.zero;
    }
}