using UnityEngine;

public class SfxController : MonoBehaviour
{
    public static SfxController Instance;

    public AudioSource CorrectAnswerSfx;

    public AudioSource GameOverSfx;

    public AudioSource StartSfx;

    public AudioSource IncorrectAnswerSfx;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public void PlayStartSfx()
    {
        PlaySfx(StartSfx);
    }

    public void PlayCorrectAnswerSfx()
    {
        PlaySfx(CorrectAnswerSfx);
    }

    public void PlayIncorectAnswerSfx()
    {
        PlaySfx(IncorrectAnswerSfx);
    }

    public void PlayGameOverSfx()
    {
        PlaySfx(GameOverSfx);
    }

    private void PlaySfx(AudioSource sfx)
    {
        sfx.Stop();
        sfx.Play();
    }
}