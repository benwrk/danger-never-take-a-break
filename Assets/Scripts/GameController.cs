using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public const float GameTime = 150.00f;
    public const float TimeScoreMultiplier = 100.0f;
    public static GameController Instance;

    public float GameSpeed = 6.0f;
    public float DifficultyMultiplier = 1.0f;

    public float TimeLeft;
    public GameState State;

    public float Score;

    public enum GameState
    {
        NotStarted,
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
        ResetCounters();
    }

    // Update is called once per frame

    void Update()
    {
        switch (State)
        {
            case GameState.Active:
                TimeLeft -= Time.deltaTime;
                Score += Time.deltaTime * DifficultyMultiplier * TimeScoreMultiplier;
                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    Pause();
                }
                break;
            case GameState.NotStarted:
                break;
            case GameState.Over:
                break;
            case GameState.Paused:
                if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp("joystick 1 button 9"))
                {
                    Resume();
                }
                break;
        }
    }

    private void Resume()
    {
        throw new System.NotImplementedException();
    }

    private void Pause()
    {
        throw new System.NotImplementedException();
    }

    public float GetEffectiveGameSpeed()
    {
        return GameSpeed * DifficultyMultiplier;
    }


    private void StartGame()
    {
        ResetCounters();
    }

    private void ResetCounters()
    {
        TimeLeft = GameTime;
        Score = 0;
    }

    public void Restart()
    {
    }
}