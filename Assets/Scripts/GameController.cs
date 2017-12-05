using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum CarState
    {
        Stop,
        Idle,
        Accelerating,
        Damaged
    }

    public enum GameState
    {
        PreGame,
        Paused,
        Active,
        GameOver,
        Question
    }

    public static GameController Instance;

    private int _gameCounter;
    private float _timeSinceLastAccelerateKeyChange;
    private List<Question> _unusedQuestions;
    public float AccelerationMultiplier = 1.5f;
    public GameObject ActiveCanvas;
    public float AccelerateKeyChangeIntervalMax = 12f;
    public float AccelerateKeyChangeIntervalMin = 4f;
    public CarState CurrentCarState;
    public float DifficultyMultiplier = 1.0f;

    public float GameLength = 150.00f;
    public GameObject GameOverCanvas;
    public float GameSpeed = 6.0f;

    public float HpLeft;
    public float LengthDifficultyMaxMultiplier = 0.5f;
    public GameObject PauseCanvas;

    public GameObject PreGameCanvas;
    public GameObject QuestionCanvas;
    public float QuestionPenalty = 40f;
    public float QuestionRewardMultiplier = 1000f;
    public float QuestionTime = 10.0f;
    public bool QuestionTriggered;
    public float Score;
    public GameState CurrentGameState;

    public float TimeLeftToAnswer;
    public float TimeScoreMultiplier = 100.0f;
    public AccelerateKey CurrentAccelerateKey;
    private float _currentAccelerateKeyChangeInterval;

    public enum AccelerateKey
    {
        Up,
        Down,
        Left,
        Right
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Active:
                ActiveCanvas.SetActive(true);
                HpLeft -= Time.deltaTime;
                AddTimeScore();

                _timeSinceLastAccelerateKeyChange += Time.deltaTime;
                if (_timeSinceLastAccelerateKeyChange >= _currentAccelerateKeyChangeInterval)
                {
                    _timeSinceLastAccelerateKeyChange = 0f;
                    _currentAccelerateKeyChangeInterval =
                        Random.Range(AccelerateKeyChangeIntervalMin, AccelerateKeyChangeIntervalMax);
                    var previousAccelerateKey = CurrentAccelerateKey;
                    while (CurrentAccelerateKey == previousAccelerateKey)
                    {
                        CurrentAccelerateKey = Random.value > 0.5
                            ? Random.value > 0.5
                                ? AccelerateKey.Up
                                : AccelerateKey.Down
                            : Random.value > 0.5
                                ? AccelerateKey.Left
                                : AccelerateKey.Right;
                    }
                }

                var accelerateKeyPressed = false;

                switch (CurrentAccelerateKey)
                {
                    case AccelerateKey.Up:
                        accelerateKeyPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey("joystick 1 button 0");
                        break;
                    case AccelerateKey.Down:
                        accelerateKeyPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetKey("joystick 1 button 1");
                        break;
                    case AccelerateKey.Left:
                        accelerateKeyPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("joystick 1 button 2");
                        break;
                    case AccelerateKey.Right:
                        accelerateKeyPressed = Input.GetKey(KeyCode.RightArrow) || Input.GetKey("joystick 1 button 3");
                        break;
                }

                CurrentCarState = accelerateKeyPressed ? CarState.Accelerating : CarState.Idle;

                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    ActiveCanvas.SetActive(false);
                    CurrentGameState = GameState.Paused;
                }

                if (QuestionTriggered)
                {
                    QuestionTriggered = false;
                    TimeLeftToAnswer = QuestionTime;
                    CurrentGameState = GameState.Question;
                    ActiveCanvas.SetActive(false);
                }

                if (HpLeft <= 0f)
                {
                    ActiveCanvas.SetActive(false);
                    CurrentGameState = GameState.GameOver;
                }
                break;
            case GameState.PreGame:
                PreGameCanvas.SetActive(true);
                CurrentCarState = CarState.Stop;
                if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    PreGameCanvas.SetActive(false);
                    Restart();
                    CurrentGameState = GameState.Active;
                }
                break;
            case GameState.GameOver:
                GameOverCanvas.SetActive(true);
                CurrentCarState = CarState.Damaged;
                if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    Restart();
                    CurrentGameState = GameState.Active;
                    GameOverCanvas.SetActive(false);
                }
                break;
            case GameState.Paused:
                PauseCanvas.SetActive(true);
                CurrentCarState = CarState.Stop;
                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    CurrentGameState = GameState.Active;
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
               AccelerationMultiplier * (CurrentCarState == CarState.Accelerating ? AccelerationMultiplier : 1f) *
               (CurrentGameState == GameState.Active ? 1f : 0f);
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
        _unusedQuestions = new List<Question>(Question.QuestionList1);
        _unusedQuestions.AddRange(Question.QuestionList2);
    }

    public Question GetQuestion()
    {
        //var i = Random.Range(0, _unusedQuestions.Count);
        //var ret = _unusedQuestions[i];
        //_unusedQuestions.RemoveAt(i);
        var ret = _unusedQuestions[0];
        _unusedQuestions.RemoveAt(0);
        return ret;
    }

    public void QuestionAnswered(bool isCorrectAnswer)
    {
        if (isCorrectAnswer)
            Score += TimeLeftToAnswer * QuestionRewardMultiplier + QuestionRewardMultiplier;
        else
            HpLeft -= QuestionPenalty;
        CurrentGameState = GameState.Active;
        QuestionCanvas.SetActive(false);
    }
}