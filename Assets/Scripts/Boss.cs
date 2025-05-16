using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //private GameObject player;

    //Rocket variables
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 3f)]
    [SerializeField] private float laserTimer = 2f;
    [SerializeField] private float speed = 10f;

    //Minion variables
    [SerializeField] Transform minionSpawnPoint;
    [SerializeField] Transform minionPrefab;
    private float minionTimer = 5f;
    public int currentMinion;

    public Health health;

    private void Start()
    {
        //Contols the amount of time between laser shots
        StartCoroutine(Shoot(laserTimer));

        //player = GameObject.FindGameObjectWithTag("Player");
    }

    //Update function which checks if the current minion variable has no value i.e. there is no minion
    private void Update()
    {
        //In this case, spawn a new minion and assign it to the current minion variable
        if (currentMinion == 0)
        {
            //Controls the amount of time between minion spawns
            StartCoroutine(Spawn(minionTimer));

            currentMinion = 1;
            Debug.Log("SpawnActivate");
        }

        //health.UpdateHealth();

    }

    public IEnumerator Spawn(float timePeriod)
    {
        //Spawns minion
        yield return new WaitForSeconds(timePeriod);
        Instantiate(minionPrefab, minionSpawnPoint.position, minionSpawnPoint.rotation);
    }


    private IEnumerator Shoot(float timePeriod)
    {
        while (true)
        {
            //Spawns rocket
            Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
            //Suspends the coroutine for set amount of seconds
            yield return new WaitForSeconds(timePeriod);
        }
    }

    public void Deactivate()
    {
        Destroy(gameObject);
    }
}
