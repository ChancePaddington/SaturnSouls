using System.Collections;
using UnityEngine;

public class SceneFadeController : MonoBehaviour
{
    [SerializeField] private float sceneFadeDuration;
    //private SceneFade sceneFade;

    private void Awake()
    {
        //sceneFade = GetComponentInChildren<SceneFade>();
    }

    /*private IEnumerator Start()
    {
        yield return sceneFade.FadeInCoroutine(sceneFadeDuration);
    }*/


}
