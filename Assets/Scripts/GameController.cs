using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public float GameLength = 150.00f;
    public float TimeScoreMultiplier = 100.0f;
    public float GameSpeed = 6.0f;
    public float DifficultyMultiplier = 1.0f;
    public float AccelerationMultiplier = 1.5f;

    public float HpLeft;
    public float Score;
    public GameState State;
    public CState CarState;

    public GameObject PreGameCanvas;
    public GameObject GameOverCanvas;
    public GameObject ActiveCanvas;
    public GameObject PauseCanvas;

    public enum GameState
    {
        PreGame,
        Paused,
        Active,
        GameOver
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
        }
    }

    public float GetEffectiveGameSpeed()
    {
        return GameSpeed * DifficultyMultiplier * AccelerationMultiplier * (CarState == CState.Accelerating ? AccelerationMultiplier : 1f);
    }

    private void AddScore()
    {
        Score += Time.deltaTime * DifficultyMultiplier * TimeScoreMultiplier * (CarState == CState.Accelerating ? AccelerationMultiplier : 1f);
    }

    public void Restart()
    {
        HpLeft = GameLength;
        Score = 0;
    }
}