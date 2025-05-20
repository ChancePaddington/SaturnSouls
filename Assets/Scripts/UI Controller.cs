using UnityEngine;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    public List<GameObject> enemies;

    private GameObject[] enemy;
    public int nextScene;

    public void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        enemies.AddRange(enemy);
    }

    private void Update()
    {
        NextLevel();
    }

    //public void PlayBossOne()
    // {
    //     SceneController.LoadScene(1);
    // }

    // public void PlayBossTwo()
    // {
    //     SceneController.LoadScene(2);
    // }

    public void Restart()
    {
        SceneController.Restart();
    }

    public void NextLevel()
    {
        if (enemies.Count == 0)
        {
            SceneController.LoadScene(nextScene);
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
