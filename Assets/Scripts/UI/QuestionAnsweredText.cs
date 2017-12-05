using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestionAnsweredText : MonoBehaviour
    {
        private void Update()
        {
            GetComponent<Text>().text = GameController.Instance.QuestionsAnsweredCorrectly + "/" +
                                        GameController.Instance.QuestionsAnswered;
        }
    }
}