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

    public float HpLeft;
    public float Score;
    public GameState State;

    public Canvas PreGameCanvas;
    public Canvas GameOverCanvas;
    public Canvas ActiveCanvas;
    public Canvas PauseCanvas;

    public enum GameState
    {
        PreGame,
        Paused,
        Active,
        Over
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
                HpLeft -= Time.deltaTime;
                Score += Time.deltaTime * DifficultyMultiplier * TimeScoreMultiplier;
                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    State = GameState.Paused;
                }
                break;
            case GameState.PreGame:
                if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    Restart();
                    State = GameState.Active;
                }
                break;
            case GameState.Over:
                if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    Restart();
                    State = GameState.Active;
                }
                break;
            case GameState.Paused:
                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    State = GameState.Active;
                }
                break;
        }
    }

    public float GetEffectiveGameSpeed()
    {
        return GameSpeed * DifficultyMultiplier;
    }

    public void Restart()
    {
        HpLeft = GameLength;
        Score = 0;
    }
}