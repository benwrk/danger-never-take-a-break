using UnityEngine;

public class Car : MonoBehaviour
{
    private Animator _animator;
    public RuntimeAnimatorController BlueCarAnimatorController;
    public RuntimeAnimatorController GreenCarAnimatorController;
    public RuntimeAnimatorController RedCarAnimatorController;
    public RuntimeAnimatorController YellowCarAnimatorController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (GameController.Instance.CurrentCarColor)
        {
            case GameController.CarColor.Blue:
                _animator.runtimeAnimatorController = BlueCarAnimatorController;
                break;
            case GameController.CarColor.Green:
                _animator.runtimeAnimatorController = GreenCarAnimatorController;
                break;
            case GameController.CarColor.Red:
                _animator.runtimeAnimatorController = RedCarAnimatorController;
                break;
            case GameController.CarColor.Yellow:
                _animator.runtimeAnimatorController = YellowCarAnimatorController;
                break;
        }
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