using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [Range (0f, 3f)]
    [SerializeField] private float laserTimer = 2f;
    //private GameObject player;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;

    //Minion variables
    [SerializeField] Transform minionSpawnPoint;
    [SerializeField] Transform minionPrefab;
    private float minionTimer = 5f;
    public int currentMinion;

    //Tutorial UI
    public TextMeshProUGUI tutorialText;

    private void Start()
    {
        //Contols the amount of time between laser shots
        StartCoroutine(Shoot(laserTimer));

    }

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
    public IEnumerator Spawn(float timePeriod)
    {
        //Spawns minion
        yield return new WaitForSeconds(timePeriod);
        Instantiate(minionPrefab, minionSpawnPoint.position, minionSpawnPoint.rotation);
    }

    public void Deactivate()
    {
        //Destroy(tutorialText);
        Destroy(gameObject);
    }
}
