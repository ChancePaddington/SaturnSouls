using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    //Meteor variables
    [SerializeField] Transform meteorASpawnPoint;
    [SerializeField] Transform meteorAPrefab;
    [Range(0.1f, 60f)]
    [SerializeField] private float meteorTimer = 10f;
    public int currentMeteor;

    //Update function which checks if the current meteor variable has no value i.e. there is no meteor
    private void Update()
    {
        //In this case, spawn a new meteor and assign it to the current minion variable
        if (currentMeteor == 0)
        {
            //Controls the amount of time between meteor spawns
            StartCoroutine(SpawnMeteor(meteorTimer));

    currentMeteor = 1;
            
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

}
