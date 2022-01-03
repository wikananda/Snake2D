using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text finalScore, gameOver, textFinalScore;
    GameObject endPanel, pausePanel;
    [SerializeField] TMP_Text textScore;

    AudioSource audioSource;
    [SerializeField] AudioClip growSFX;
    [SerializeField] AudioClip gameOverSFX;

    void Start()
    {
        textScore.text = score.ToString();
        endPanel = GameObject.Find("EndPanel");
        pausePanel = GameObject.Find("PausePanel");
        endPanel.SetActive(false);
        pausePanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    internal void Pause()
    {
        pausePanel.SetActive(true);
    }

    internal void Unpause()
    {
        pausePanel.SetActive(false);
    }

    internal void ScoreUp()
    {
        audioSource.PlayOneShot(growSFX);
        score++;
        textScore.text = score.ToString();
    }

    internal void ResetScore()
    {
        score = 0;
        textScore.text = score.ToString();
    }

    internal int GetScore()
    {
        return score;
    }

    internal void FinalResult()
    {
        if (endPanel.activeSelf == false)
        {
            audioSource.PlayOneShot(gameOverSFX);
            finalScore.text = score.ToString();
            endPanel.SetActive(true);
        }
    }

    internal void QuitResult()
    {
        endPanel.SetActive(false);
    }

}
