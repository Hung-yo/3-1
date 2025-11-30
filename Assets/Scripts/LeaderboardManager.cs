using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LeaderboardManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI leaderboardText;
    List<int> highScores = new List<int>();
    void Start()
    {
        LoadScores();
        UpdateLeaderboardDisplay();
    }

    public void UpdateScore()
    {
        int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        highScores.Add(currentScore);
        highScores.Sort((a, b) => b.CompareTo(a));
        if (highScores.Count > 5)
            highScores.RemoveAt(5);
        SaveScores();
        UpdateLeaderboardDisplay();
    }

    private void LoadScores()
    {
        highScores.Clear();
        for (int i = 1; i <= 5; i++)
        {
            highScores.Add(PlayerPrefs.GetInt($"Score{i}", 0));
        }
    }

    private void SaveScores()
    {
        for (int i = 1; i <= highScores.Count; i++)
        {
            PlayerPrefs.SetInt($"Score{i}", highScores[i - 1]);
        }
        PlayerPrefs.Save();
    }

    private void UpdateLeaderboardDisplay()
    {
        leaderboardText.text = "";
        string[] suffixes = { "st", "nd", "rd", "th", "th" };
        for (int i = 0; i < highScores.Count; i++)
        {
            string suffix = i < 3 ? suffixes[i] : suffixes[3];
            leaderboardText.text += $"{i + 1}{suffix}: {highScores[i]}\n";
        }
    }
}
