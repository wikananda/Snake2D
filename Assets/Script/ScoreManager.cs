using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text finalScore, gameOver, textFinalScore;
    GameObject endPanel;
    [SerializeField] TMP_Text textScore;

    void Start()
    {
        textScore.text = score.ToString();
        endPanel = GameObject.Find("EndPanel");
        endPanel.SetActive(false);
    }

    internal void ScoreUp()
    {
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
        finalScore.text = score.ToString();
        endPanel.SetActive(true);
    }

    internal void QuitResult()
    {
        endPanel.SetActive(false);
    }
}
