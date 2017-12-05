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
        switch (GameController.Instance.State)
        {
            case GameController.GameState.Active:
                PlaySolo(GameController.Instance.CarState == GameController.CState.Accelerating ? AcceleratingBgm : ActiveBgm);
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