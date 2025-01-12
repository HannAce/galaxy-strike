using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverMenu : Menu
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI currentHighScoreText;
    [SerializeField] private TextMeshProUGUI newHighScoreText;

    private void OnEnable()
    {
        Scoreboard.OnHighScoreUpdated += HandleNewHighScore;
        currentScoreText.text = "Your score: " + Scoreboard.Instance.Score;
        currentHighScoreText.gameObject.SetActive(true);
        currentHighScoreText.text = "Current high score: " + Scoreboard.Instance.HighScore;
    }

    private void OnDisable()
    {
        Scoreboard.OnHighScoreUpdated -= HandleNewHighScore;
    }

    // If not using a parameter, can be called _
    private void HandleNewHighScore(int _)
    {
        currentHighScoreText.gameObject.SetActive(false);
        newHighScoreText.text = "NEW HIGH SCORE!";
        newHighScoreText.gameObject.SetActive(true);
    }
}
