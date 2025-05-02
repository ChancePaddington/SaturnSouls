using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 6f;

    private Rigidbody2D rb;
    private GameObject player;
    public float force = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        //Destroys sprite after lifeTime expires
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        //Recognises if rocket hits Boss class collider
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Destroys Boss sprite on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
