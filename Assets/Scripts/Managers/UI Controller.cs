using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public List<GameObject> enemies;
    private GameObject[] enemy;
    public int nextScene;
    public Image fadeImage;

    private void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        enemies.AddRange(enemy);
        if (fadeImage != null)
        {
            StartCoroutine(FadeOut());
        }
    }

    private void Update()
    {
        if (enemies.Count == 0)
        {
            NextLevel(1);
        }
    }

    public void Restart()
    {
        SceneController.Restart();
    }

    public void NextLevel(float duration)
    {
        if (fadeImage != null)
        {
            StartCoroutine(Fader(duration));
        }
    }

    IEnumerator Fader(float duration)
    {
        float t = 0;
        Color c = fadeImage.color;
        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = t / duration;
            fadeImage.color = c;
            yield return null;
        }

        SceneController.LoadScene(nextScene);
    }

    IEnumerator FadeOut()
    {
        float t = 0;
        Color c = fadeImage.color;
        while (t < 1)
        {
            t += Time.deltaTime;
            c.a = 1f - (t / 1f);
            fadeImage.color = c;
            yield return null;
        }
    }

    public void SceneLoad(int sceneIndex)
    {
        SceneController.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
