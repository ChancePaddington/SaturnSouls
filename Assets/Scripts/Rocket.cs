using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 6f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        //Destroys rocket when life time expires
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Recognises if rocket hits Boss class collider
        if (collision.gameObject.GetComponent<Boss>() != null)
        {
            //Destroys Boss sprite on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        //Rocognise if rocket hits Minion class collider
        if (collision.gameObject.GetComponent<Minion>() != null)
        {
            //Destroys Minion sprite on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        //Recognise if rocket hits Turret class collider
        if (collision.gameObject.GetComponent<Turret>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

}
