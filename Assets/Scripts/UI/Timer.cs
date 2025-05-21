using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestTimeText;
    public string playerPrefsKey = "Best Time";
    private float startTime;
    private float bestTime = float.MaxValue;

    private void Start()
    {
        startTime = Time.time;
        bestTime = PlayerPrefs.GetFloat(playerPrefsKey, bestTime);
        UpdateBestTimeText();
    }

    private void Update()
    {
        float currentTime = Time.time - startTime;
        UpdateCurrentTimeText(currentTime);
    }

    private void OnDisable()
    {
        if (Time.time - startTime <  bestTime)
        {
            bestTime = Time.time - startTime;
            PlayerPrefs.SetFloat(playerPrefsKey, bestTime);
            PlayerPrefs.Save();
            UpdateBestTimeText();
        }
    }

    private void UpdateCurrentTimeText(float time)
    {
        string formattedTime = string.Format("{0:00}:{1:00}.{2:000}",
        Mathf.FloorToInt(time / 60),
        Mathf.FloorToInt(time) % 60,
        Mathf.FloorToInt(time * 1000) % 1000);
        currentTimeText.text = formattedTime;
    }

    private void UpdateBestTimeText()
    {
        string formattedTime = string.Format("{0:00}:{1:00}.{2:000}",
        Mathf.FloorToInt(bestTime / 60),
        Mathf.FloorToInt(bestTime) % 60,
        Mathf.FloorToInt(bestTime * 1000) % 1000);
        bestTimeText.text = formattedTime;
    }

}
