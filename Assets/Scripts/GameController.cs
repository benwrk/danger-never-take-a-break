using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public float GameLength = 150.00f;
    public float TimeScoreMultiplier = 100.0f;
    public float GameSpeed = 6.0f;
    public float DifficultyMultiplier = 1.0f;
    public float AccelerationMultiplier = 1.5f;
    public float LengthDifficultyMaxMultiplier = 0.5f;
    public float QuestionTime = 10.0f;
    public float QuestionPenalty = 40f;
    public float QuestionRewardMultiplier = 1000f;

 
    public float TimeLeftToAnswer;

    public float HpLeft;
    public float Score;
    public GameState State;
    public CState CarState;

    public GameObject PreGameCanvas;
    public GameObject GameOverCanvas;
    public GameObject ActiveCanvas;
    public GameObject PauseCanvas;
    public GameObject QuestionCanvas;

    private int _gameCounter;
    private List<Question> _unusedQuestions;
    public bool QuestionTriggered;

    public enum GameState
    {
        PreGame,
        Paused,
        Active,
        GameOver,
        Question
    }

    public enum CState
    {
        Stop,
        Idle,
        Accelerating,
        Damaged
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        switch (State)
        {
            case GameState.Active:
                ActiveCanvas.SetActive(true);
                HpLeft -= Time.deltaTime;
                AddTimeScore();

                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    ActiveCanvas.SetActive(false);
                    State = GameState.Paused;
                }

                CarState = (Input.GetKey(KeyCode.W) || Input.GetKey("joystick 1 button 3"))
                    ? CState.Accelerating
                    : CState.Idle;

                if (QuestionTriggered)
                {
                    QuestionTriggered = false;
                    TimeLeftToAnswer = QuestionTime;
                    State = GameState.Question;
                    ActiveCanvas.SetActive(false);
                }

                if (HpLeft <= 0f)
                {
                    ActiveCanvas.SetActive(false);
                    State = GameState.GameOver;
                }
                break;
            case GameState.PreGame:
                PreGameCanvas.SetActive(true);
                CarState = CState.Stop;
                if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    PreGameCanvas.SetActive(false);
                    Restart();
                    State = GameState.Active;
                }
                break;
            case GameState.GameOver:
                GameOverCanvas.SetActive(true);
                CarState = CState.Damaged;
                if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    Restart();
                    State = GameState.Active;
                    GameOverCanvas.SetActive(false);
                }
                break;
            case GameState.Paused:
                PauseCanvas.SetActive(true);
                CarState = CState.Stop;
                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    State = GameState.Active;
                    PauseCanvas.SetActive(false);
                }
                break;
            case GameState.Question:
                QuestionCanvas.SetActive(true);
                TimeLeftToAnswer -= Time.deltaTime;
                break;
        }
    }

    public float GetEffectiveGameSpeed()
    {
        return GameSpeed * (DifficultyMultiplier + DifficultyMultiplier * LengthDifficultyMaxMultiplier) *
               AccelerationMultiplier * (CarState == CState.Accelerating ? AccelerationMultiplier : 1f) *
               (State == GameState.Active ? 1f : 0f);
    }

    private void AddTimeScore()
    {
        Score += Time.deltaTime * GetEffectiveGameSpeed() * TimeScoreMultiplier;
    }

    public void Restart()
    {
        HpLeft = GameLength;
        Score = 0;
        _gameCounter++;
        //_unusedQuestions = _gameCounter % 2 == 0
        //    ? new List<Question>(Question.QuestionList1)
        //    : new List<Question>(Question.QuestionList2);
        _unusedQuestions = new List<Question>(Question.QuestionList1);
        _unusedQuestions.AddRange(Question.QuestionList2);
    }

    public Question GetQuestion()
    {
        var i = Random.Range(0, _unusedQuestions.Count);
        var ret = _unusedQuestions[i];
        _unusedQuestions.RemoveAt(i);
        return ret;
    }

    public void QuestionAnswered(bool isCorrectAnswer)
    {
        if (isCorrectAnswer)
        {
            Score += TimeLeftToAnswer * QuestionRewardMultiplier + QuestionRewardMultiplier;
        }
        else
        {
            HpLeft -= QuestionPenalty;
        }
        State = GameState.Active;
        QuestionCanvas.SetActive(false);
    }
}