using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreText : MonoBehaviour
    {

        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            GetComponent<Text>().text = ((int) GameController.Instance.Score).ToString(CultureInfo.InvariantCulture);
        }
    }
}
