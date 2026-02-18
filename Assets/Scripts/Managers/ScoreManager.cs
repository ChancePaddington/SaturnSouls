using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int highscore;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("Highscore", highscore);
    }

    void Update()
    {
        if (score > highscore)
        highscore = score;
        scoreText.text = " " + score;

        PlayerPrefs.SetInt("Highscore", highscore );
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void Reset()
    {
        score = 0;
    }
}
