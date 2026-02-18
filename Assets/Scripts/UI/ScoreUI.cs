using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreManager.Instance.scoreText = GetComponent<TMP_Text>();
    }

}
