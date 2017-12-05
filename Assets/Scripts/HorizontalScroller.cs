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
        _rigidBody.velocity = new Vector2(GameController.Instance.GetEffectiveGameSpeed() * SpeedMultiplier, 0);
    }
}