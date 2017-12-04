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
    }

    void Update()
    {
        _scrollVelocityVector = new Vector2(GameController.Instance.GetEffectiveGameSpeed() * SpeedMultiplier, 0);
        _rigidBody.velocity = GameController.Instance.State == GameController.GameState.Active ? _scrollVelocityVector : Vector2.zero;
    }
}