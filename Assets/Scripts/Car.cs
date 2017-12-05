using UnityEngine;

public class Car : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("IsAccelerating",
            GameController.Instance.CurrentCarState == GameController.CarState.Accelerating);
        _animator.SetBool("IsDamaged",
            GameController.Instance.CurrentCarState == GameController.CarState.Damaged);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("QuestionTrigger"))
            GameController.Instance.QuestionTriggered = true;
    }
}