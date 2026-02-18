using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [Range (0f, 3f)]
    [SerializeField] private float laserTimer = 2f;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private int pointsValue;

    private UIController uiCon;
    //private ScoreManager scoreManager;

    private void Start()
    {
        uiCon = FindAnyObjectByType<UIController>();

        //Contols the amount of time between laser shots
        StartCoroutine(Shoot(laserTimer));

    }

    private IEnumerator Shoot(float timePeriod)
    {
        while (true)
        {
            //Suspends the coroutine for set amount of seconds
            yield return new WaitForSeconds(timePeriod);
            //Spawns rocket
            Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
        }

    }
    
    public void Deactivate()
    {
        uiCon.enemies.Remove(gameObject);
        Destroy(gameObject);
        ScoreManager.Instance.AddPoints(pointsValue);
    }
}
