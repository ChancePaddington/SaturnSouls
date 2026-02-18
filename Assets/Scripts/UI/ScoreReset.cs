using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreManager.Instance.Reset();
    }

}
