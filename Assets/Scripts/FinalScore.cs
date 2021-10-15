using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    public static TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    private int finalScore;

    void Start()
    {
        finalScore = FindObjectOfType<GameMaster>().getFinalScore();
        finalScoreText = gameObject.GetComponent<TextMeshProUGUI>();
        finalScoreText.text = "You Got " + finalScore.ToString() + " Points";
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        if (finalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
            highScoreText.text = "High Score: " + finalScore.ToString();
        }
        
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
