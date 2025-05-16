using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //private GameObject player;
    public Health health;

    //Rocket variables
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 3f)]
    [SerializeField] private float laserTimer = 2f;
    [SerializeField] private float speed = 10f;

    //Meteor variables
    [SerializeField] Transform meteorASpawnPoint;
    [SerializeField] Transform meteorAPrefab;
    [Range(0.1f, 60f)]
    [SerializeField] private float meteorTimer = 10f;
    public int currentMeteor;


    private void Start()
    {
        //Contols the amount of time between laser shots
        StartCoroutine(Shoot(laserTimer));

        //player = GameObject.FindGameObjectWithTag("Player");
    }

    //Update function which checks if the current meteor variable has no value i.e. there is no minion
    private void Update()
    {
        //In this case, spawn a new meteor and assign it to the current minion variable
        if (currentMeteor == 0)
        {
            //Controls the amount of time between meteor spawns
            StartCoroutine(SpawnMeteor(meteorTimer));

            currentMeteor = 1;
            
        }

        //health.UpdateHealth();
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


    public IEnumerator SpawnMeteor(float timePeriod)
    {
        while (true)
        {
            yield return new WaitForSeconds(timePeriod);
            Instantiate(meteorAPrefab, meteorASpawnPoint.position, meteorASpawnPoint.rotation);
        }
    }

    public void Deactivate()
    {
        Destroy(gameObject);
    }
}
