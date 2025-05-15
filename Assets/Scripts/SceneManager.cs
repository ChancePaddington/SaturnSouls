using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public UnityEvent sceneChange;
   public float sceneChangeTime;
   public GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    //private void Update()
    //{
    //    if (enemy == null)
    //    {
    //        ChangeScene();
    //    }
    //}

    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
