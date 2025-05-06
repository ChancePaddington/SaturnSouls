using System.Collections;
using System.Threading;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameObject player;

    //Rocket variables
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 4f;
    private float laserTimer = 2f;

    //Minion variables
    [SerializeField] Transform minionSpawn;
    [SerializeField] Transform minionPrefab;
    private float minionTimer = 10f;

    private void Start()
    {
        //Contols the amount of time between laser shots
        StartCoroutine(Shoot(laserTimer));
        //Controls the amount of time between minion spawns
        StartCoroutine(Minion(minionTimer));

        player = GameObject.FindGameObjectWithTag("Player");

    }

    private IEnumerator Shoot(float timePeriod)
    {
        while (true)
        {
            //Spawns rocket
            Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
            Debug.Log("1212");
            //Suspends the coroutine for set amount of seconds
            yield return new WaitForSeconds(timePeriod);
        }
    } 

    private IEnumerator Minion(float timePeriod)
    {
        while (true)
        {
            //Spawns minion
            Instantiate(minionPrefab, minionSpawn.position, minionSpawn.rotation);
            yield return new WaitForSeconds(timePeriod);
        }
    }


}
