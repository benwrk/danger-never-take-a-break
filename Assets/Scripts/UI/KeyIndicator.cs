using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class KeyIndicator : MonoBehaviour
    {
        private List<SpriteRenderer> _keys;
        public SpriteRenderer CorrectKeyIndicator;
        public SpriteRenderer DownKeyIndicator;
        public SpriteRenderer LeftKeyIndicator;
        public SpriteRenderer RightKeyIndicator;
        public SpriteRenderer UpKeyIndicator;

        private void Start()
        {
            _keys = new List<SpriteRenderer>
            {
                UpKeyIndicator,
                DownKeyIndicator,
                LeftKeyIndicator,
                RightKeyIndicator
            };
        }

        private void Update()
        {
            switch (GameController.Instance.CurrentAccelerateKey)
            {
                case GameController.AccelerateKey.Up:
                    HighlightKey(UpKeyIndicator);
                    break;
                case GameController.AccelerateKey.Down:
                    HighlightKey(DownKeyIndicator);
                    break;
                case GameController.AccelerateKey.Left:
                    HighlightKey(LeftKeyIndicator);
                    break;
                case GameController.AccelerateKey.Right:
                    HighlightKey(RightKeyIndicator);
                    break;
            }

            CorrectKeyIndicator.color = GameController.Instance.CurrentCarState == GameController.CarState.Accelerating
                ? new Color(0.38f, 1f, 0.38f, 0.9f)
                : new Color(1f, 0.38f, 0.38f, 0.9f);
        }

        private void HighlightKey(SpriteRenderer soloKeyIndicator)
        {
            _keys.ForEach(k =>
                k.color = k == soloKeyIndicator ? new Color(1f, 1f, 1f, 0.9f) : new Color(0.5f, 0.5f, 0.5f, 0.5f));
        }
    }
}