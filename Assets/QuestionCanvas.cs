using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCanvas : MonoBehaviour
{
    public Text QuestionText;

    public List<Text> ChoiceTexts;

    private Question _currentQuestion;

    private bool _questionUsed;

    private void Start()
    {
        _questionUsed = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_questionUsed)
        {
            _currentQuestion = GameController.Instance.GetQuestion();
            _questionUsed = false;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp("joystick 1 button 6"))
            {
                HandleAnswer(1);
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp("joystick 1 button 7"))
            {
                HandleAnswer(2);
            }
            if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp("joystick 1 button 4"))
            {
                HandleAnswer(3);
            }
            if (Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp("joystick 1 button 5"))
            {
                HandleAnswer(4);
            }
        }

        QuestionText.text = _currentQuestion.Text;

        for (var i = 0; i < ChoiceTexts.Count; i++)
        {
            ChoiceTexts[i].text = _currentQuestion.Choices[i];
        }

    }

    public void HandleAnswer(int choiceNumber)
    {
        GameController.Instance.QuestionAnswered(choiceNumber - 1 == _currentQuestion.CorrectChoiceIndex);
        _questionUsed = true;
    }
}