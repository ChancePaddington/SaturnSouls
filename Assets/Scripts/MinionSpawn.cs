using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    //Minion variables
    [SerializeField] Transform minionSpawnPoint;
    [SerializeField] Transform minionPrefab;
    private float minionTimer = 5f;
    public int currentMinion;
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

    public IEnumerator Spawn(float timePeriod)
    {
        //Spawns minion
        yield return new WaitForSeconds(timePeriod);
        Instantiate(minionPrefab, minionSpawnPoint.position, minionSpawnPoint.rotation);
    }

}
