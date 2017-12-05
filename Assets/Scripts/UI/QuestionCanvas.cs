using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestionCanvas : MonoBehaviour
    {
        private GameObject _activeImage;

        private Question _currentQuestion;

        private bool _imageActivated;

        private bool _questionUsed;

        public List<Text> ChoiceTexts;

        public List<GameObject> QuestionImages;
        public Text QuestionText;

        private void Start()
        {
            _questionUsed = true;
        }

        private void Update()
        {
            if (_questionUsed)
            {
                _currentQuestion = GameController.Instance.GetQuestion();
                _questionUsed = false;
                if (_currentQuestion.QuestionNumber > 0 && _currentQuestion.QuestionNumber < 12)
                {
                    _activeImage = QuestionImages[_currentQuestion.QuestionNumber - 1];
                    _activeImage.SetActive(true);
                    _imageActivated = true;
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp("joystick 1 button 6"))
                    HandleAnswer(1);
                if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp("joystick 1 button 7"))
                    HandleAnswer(2);
                if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp("joystick 1 button 4"))
                    HandleAnswer(3);
                if (Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp("joystick 1 button 5"))
                    HandleAnswer(4);
            }

            QuestionText.text = _currentQuestion.Text;

            for (var i = 0; i < ChoiceTexts.Count; i++)
                ChoiceTexts[i].text = _currentQuestion.Choices[i];
        }

        /// <summary>
        ///     Handle the action of answering a question.
        ///     Needs to be public to be callable from Unity UI buttons!
        /// </summary>
        /// <param name="choiceNumber">0-indexed number of selected choice</param>
        public void HandleAnswer(int choiceNumber)
        {
            if (_imageActivated)
            {
                _activeImage.SetActive(false);
                _imageActivated = false;
            }
            GameController.Instance.QuestionAnswered(choiceNumber - 1 == _currentQuestion.CorrectChoiceIndex);
            _questionUsed = true;
        }
    }
}