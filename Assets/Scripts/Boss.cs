using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Rocket variables
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    //[SerializeField] private float fireRate = 5f;
    [SerializeField] private float timer = 2f;

    
    private void Start()
    {
        StartCoroutine(Shoot(timer));
    }
   
    IEnumerator Shoot(float timePeriod)
    {
        while (true)
        {
            Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
            yield return new WaitForSeconds(timePeriod);
        }
    }

}
