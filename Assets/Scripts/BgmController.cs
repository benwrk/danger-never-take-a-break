using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{
    public BgmController Instance;

    public AudioSource PreGameBgm;

    public AudioSource ActiveBgm;

    public AudioSource GameOverBgm;

    public AudioSource AcceleratingBgm;

    public AudioSource QuestionBgm;

    private List<AudioSource> _bgmList;

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

    private void Start()
    {
        _bgmList = new List<AudioSource>
        {
            PreGameBgm,
            ActiveBgm,
            GameOverBgm,
            AcceleratingBgm,
            QuestionBgm
        };
    }

    private void Update()
    {
        switch (GameController.Instance.CurrentGameState)
        {
            case GameController.GameState.Active:
                if (GameController.Instance.CurrentCarState == GameController.CarState.Accelerating)
                {
                    AcceleratingBgm.pitch = 1.3f;
                    PlaySolo(AcceleratingBgm);
                }
                else
                {
                    AcceleratingBgm.pitch = 1.2f;
                    PlaySolo(AcceleratingBgm);
                }
                //PlaySolo(GameController.Instance.CurrentCarState == GameController.CarState.Accelerating ? AcceleratingBgm : ActiveBgm);
                break;
            case GameController.GameState.PreGame:
            case GameController.GameState.Paused:
                PlaySolo(PreGameBgm);
                break;
            case GameController.GameState.GameOver:
                PlaySolo(GameOverBgm);
                break;
            case GameController.GameState.Question:
                PlaySolo(QuestionBgm);
                break;
        }
    }

    private void PlaySolo(AudioSource soloSource)
    {
        foreach (var source in _bgmList)
        {
            if (source == soloSource)
            {
                if (!source.isPlaying)
                {
                    source.Play();
                }
            }
            else
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
            }
        }
    }
}