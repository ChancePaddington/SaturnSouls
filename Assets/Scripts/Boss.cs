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
    private float timer;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        //Destroys rocket when life time expires
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
    }

}
