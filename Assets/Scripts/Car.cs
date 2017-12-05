using UnityEngine;

public class Car : MonoBehaviour
{
    private Animator _animator;

    // Use this for initialization
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameController.Instance.CarState == GameController.CState.Accelerating)
        {
            _animator.SetBool("IsAccelerating", true);
        }
        else
        {
            _animator.SetBool("IsAccelerating", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("QuestionTrigger"))
        {
            GameController.Instance.QuestionTriggered = true;
        }
    }
}