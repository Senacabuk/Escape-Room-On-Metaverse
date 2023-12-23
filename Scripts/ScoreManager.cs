using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    private void Start()
{
    // Load and display the saved scores
    string scoreString = "";
    for (int i = 1; i <= 10; i++)
    {
        string timeKey = "time" + i;
        string scoreKey = "score" + i;
        if (PlayerPrefs.HasKey(timeKey) && PlayerPrefs.HasKey(scoreKey))
        {
            float? time = PlayerPrefs.GetFloat(timeKey);
            int? score = PlayerPrefs.GetInt(scoreKey);
            if (time != null && score != null && score > 0)
            {
                scoreString += FormatTime(time.Value) + "   " + score.Value + "\n";
            }
            else
            {
                // Invalid score value, append a space
                scoreString += " \n";
            }
        }
        else
        {
            // Append a space if either key is missing
            scoreString += " \n";
        }
    }
    if (scoreText != null)
    {
        scoreText.text = scoreString;
    }
}




    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
    public void ResetScores()
    {
        // Clear all saved scores
        for (int i = 1; i <= 10; i++)
        {
            string timeKey = "time" + i;
            string scoreKey = "score" + i;
            PlayerPrefs.DeleteKey(timeKey);
            PlayerPrefs.DeleteKey(scoreKey);
        }
        
    }
}
