using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreText : MonoBehaviour
    {
        private void Update()
        {
            GetComponent<Text>().text = ((int) GameController.Instance.Score).ToString(CultureInfo.InvariantCulture);
        }
    }
}