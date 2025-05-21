using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    //Behaviour
    [Range(1, 20)]
    [SerializeField] private float speed = 10f;
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 6f;

    //Audio
    [SerializeField] AudioClip fireSound;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    private Rigidbody2D rb;
    public int damage = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;

        //Play sound FX
        SoundManager.instance.PlaySoundFXClip(fireSound, transform, volume);
     
        //Destroys rocket when life time expires
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Recognises if rocket hits Boss class collider
        if (otherCollider.gameObject.GetComponent<Boss>() != null)
        {
            //Call Health class to deal damage to health bar
            Health health = otherCollider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        //Rocognise if rocket hits Minion class collider
        if (otherCollider.gameObject.GetComponent<Minion>() != null)
        {
            //Call Health class to deal damage to health bar
            Health health = otherCollider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        //Recognise if rocket hits Turret class collider
        if (otherCollider.gameObject.GetComponent<Turret>() != null)
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

}
