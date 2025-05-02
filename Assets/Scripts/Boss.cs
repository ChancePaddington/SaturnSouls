using System.Collections;
using System.Threading;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Rocket variables
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 4f;
    private float timer = 2f;

    private void Start()
    {
        StartCoroutine(Shoot(timer));
        Debug.Log("Coroutine Check");
    }

    private IEnumerator Shoot(float timePeriod)
    {
        while (true)
        {
            Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
            Debug.Log("1212");
            yield return new WaitForSeconds(timePeriod);
        }
    } 

}
