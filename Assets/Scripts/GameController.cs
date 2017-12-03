using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static readonly float GameTime = 150.00f;
    public static GameController Instance;

    public Text TimeText;
    public Text ScoreText;

    private float _timeLeft;
    private float _score;

    public enum GameState
    {
        NotStarted, Paused, Active, Over
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
        _timeLeft -= Time.deltaTime;

        UpdateUI();
    }

    private void UpdateUI()
    {
        
    }

    private void StartGame()
    {
        ResetCounters();
    }

    private void ResetCounters()
    {
        _timeLeft = GameTime;
        _score = 0;
    }

    public void Restart()
    {
        
    }
}
