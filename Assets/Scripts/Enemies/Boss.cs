using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Health health;
    private UIController uiCon;

    //Rocket variables
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 3f)]
    [SerializeField] private float laserTimer = 2f;
    //[SerializeField] private float speed = 10f;

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
    }
}
