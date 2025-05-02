using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 6f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed; 
        //Destoys sprite after set time
        Destroy(gameObject, lifeTime);
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        //Recognises if rocket hits PlayerController class collider
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Destroys Player sprite on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
