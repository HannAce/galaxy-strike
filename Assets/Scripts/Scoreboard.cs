using System;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviourSingleton<Scoreboard>
{
    [SerializeField] private TextMeshProUGUI scoreboardText;
    
    private int m_score = 0;
    
    public static Action<int> OnHighScoreUpdated;
    
    public int HighScore => PlayerPrefs.GetInt("HighScore", 0);
    public int Score => m_score;

    public void IncreaseScore(int amount)
    {
        m_score += amount;
        scoreboardText.text = m_score.ToString();
    }

    public void TrySetHighScore()
    {
        if (m_score <= HighScore)
        {
            return;
        }
        
        PlayerPrefs.SetInt("HighScore", m_score);
        OnHighScoreUpdated?.Invoke(m_score);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        OnHighScoreUpdated?.Invoke(m_score);
    }
}
