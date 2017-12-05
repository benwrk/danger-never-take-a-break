using UnityEngine;

namespace UI
{
    public class HpGauge : MonoBehaviour
    {
        private float _originalX;

        private void Start()
        {
            _originalX = transform.localScale.x;
        }

        private void Update()
        {
            transform.localScale =
                new Vector3(_originalX * (GameController.Instance.HpLeft / GameController.Instance.GameLength),
                    transform.localScale.y, transform.localScale.z);
        }
    }
}