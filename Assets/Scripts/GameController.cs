using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public float GameLength = 150.00f;
    public float ScoreMultiplier = 100.0f;
    public float GameSpeed = 6.0f;
    public float DifficultyMultiplier = 1.0f;
    public float AccelerationMultiplier = 1.5f;
    public float LengthDifficultyMaxMultiplier = 0.5f;
    public float QuestionInterval = 10.0f;
    public float QuestionTime = 10.0f;
    public float WrongPenalty = 40f;

    private float _timeSinceLastQuestion;
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

    void Awake()
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

    // Update is called once per frame

    void Update()
    {
        switch (State)
        {
            case GameState.Active:
                ActiveCanvas.SetActive(true);
                HpLeft -= Time.deltaTime;
                AddScore();

                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    ActiveCanvas.SetActive(false);
                    State = GameState.Paused;
                }

                CarState = (Input.GetKey(KeyCode.W) || Input.GetKey("joystick 1 button 3"))
                    ? CState.Accelerating
                    : CState.Idle;

                _timeSinceLastQuestion += Time.deltaTime * GetEffectiveGameSpeed() / 15f;

                if (_timeSinceLastQuestion >= QuestionInterval)
                {
                    _timeSinceLastQuestion = 0f;
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
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp("joystick 1 button 6"))
                {
                    State = GameState.Active;
                    QuestionCanvas.SetActive(false);
                    //TODO: FIX THIS
                    //Score += TimeLeftToAnswer * ScoreMultiplier;
                }
                if (TimeLeftToAnswer <= 0f)
                {
                    HpLeft -= WrongPenalty;
                    State = GameState.Active;
                    QuestionCanvas.SetActive(false);
                }
                if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp("joystick 1 button 7"))
                {
                    HpLeft -= WrongPenalty;
                    State = GameState.Active;
                    QuestionCanvas.SetActive(false);
                }
                if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp("joystick 1 button 4"))
                {
                    HpLeft -= WrongPenalty;
                    State = GameState.Active;
                    QuestionCanvas.SetActive(false);
                }
                if (Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp("joystick 1 button 5"))
                {
                    HpLeft -= WrongPenalty;
                    State = GameState.Active;
                    QuestionCanvas.SetActive(false);
                }
                break;
        }
    }

    public float GetEffectiveGameSpeed()
    {
        return GameSpeed * (DifficultyMultiplier + DifficultyMultiplier * LengthDifficultyMaxMultiplier) *
               AccelerationMultiplier * (CarState == CState.Accelerating ? AccelerationMultiplier : 1f) *
               (State == GameState.Active ? 1f : 0f);
    }

    private void AddScore()
    {
        Score += Time.deltaTime * GetEffectiveGameSpeed() * ScoreMultiplier;
    }

    public void Restart()
    {
        HpLeft = GameLength;
        Score = 0;
    }
}