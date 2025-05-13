using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 6f;

    private Rigidbody2D rb;
    private GameObject player;
    private GameObject boss;
    public float force = 1.0f;
    public int damage = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");

        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        //Destroys sprite after lifeTime expires
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Call Health class to deal damage to health bar
        Health health = otherCollider.GetComponent<Health>();
        if (health != null)
        {
          health.TakeDamage(damage);
        }
          Destroy(gameObject);

    }

}
