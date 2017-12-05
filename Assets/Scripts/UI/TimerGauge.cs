using UnityEngine;

namespace UI
{
    public class TimerGauge : MonoBehaviour
    {
        private float _originalX;

        private void Start()
        {
            _originalX = transform.localScale.x;
        }

        private void Update()
        {
            transform.localScale =
                new Vector3(
                    _originalX * (GameController.Instance.TimeLeftToAnswer / GameController.Instance.QuestionTime),
                    transform.localScale.y, transform.localScale.z);
        }
    }
}