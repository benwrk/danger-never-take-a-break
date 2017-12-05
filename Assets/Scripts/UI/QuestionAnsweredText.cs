using UnityEngine;
using UnityEngine.UI;

public class QuestionAnsweredText : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = GameController.Instance.QuestionsAnsweredCorrectly + "/" +
                                    GameController.Instance.QuestionsAnswered;
    }
}