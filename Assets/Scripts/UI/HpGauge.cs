using UnityEngine;

namespace UI
{
    public class HpGauge : MonoBehaviour
    {
        private float _originalX;
        // Use this for initialization
        private void Start()
        {
            _originalX = transform.localScale.x;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.localScale = new Vector3(_originalX * (GameController.Instance.HpLeft / GameController.Instance.GameLength), transform.localScale.y, transform.localScale.z);
        }
    }
}
