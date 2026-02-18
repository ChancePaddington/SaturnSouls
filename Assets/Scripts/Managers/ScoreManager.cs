using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score = 0;
    public static int highscore = 0;
    public TMP_Text scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", highscore); 
    }

    void Update()
    {
        if (score > highscore)
        highscore = score;
        //scoreText.text = "" + score;

        PlayerPrefs.SetInt("Highscore", highscore );
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + score;
        }
    }

    public void Reset()
    {
        score = 0;
        scoreText = null;
    }
}
