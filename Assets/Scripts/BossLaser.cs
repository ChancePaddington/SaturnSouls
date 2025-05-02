using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 6f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        //Recognises if rocket hits Boss class collider
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Destroys Boss sprite on collision
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
