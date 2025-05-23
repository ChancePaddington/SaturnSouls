using System;
using Unity.VisualScripting;
using UnityEngine;

public class Minion : MonoBehaviour
{
    private Rigidbody2D rb;

    //Behaviour variables
    [Range(1, 20)]
    [SerializeField] private float speed = 20f;
    [Range(1, 20)]
    [SerializeField] private float lifeTime = 20f;
    public int damage = 10;

    //Enemy class needed to talk to
    public SoundLoopManager soundLoop;
    public MinionSpawn spawn;

    //Waypoint variables
    public float waitingAtWaypoint = 3f;
    public GameObject waypointA;
    public GameObject waypointB;
    private GameObject currentTarget;

    //Audio
    [SerializeField] AudioClip alarmSound;
    public SoundLoopManager soundLoopManager;
    public SoundManager soundManager;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;

        //Finds the game object with the tag to move to 
        waypointA = GameObject.FindGameObjectWithTag("Minion Waypoint A");
        waypointB = GameObject.FindGameObjectWithTag("Minion Waypoint B");

        spawn = FindAnyObjectByType<MinionSpawn>();
        soundLoop = FindAnyObjectByType<SoundLoopManager>();

        Vector3 direction = waypointA.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        //Play audio
        //SoundManager.instance.PlayLoopFXClip(alarmSound, transform, volume);

        Invoke("Deactivate", lifeTime);
        currentTarget = waypointA;

    }

    public void Update()
    {
        MoveToTarget();
    }


    public void MoveToTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.transform.position);
        bool isCloseToTarget = distanceToTarget < 0.5f;

        if (isCloseToTarget)
        {
            SwitchTarget();
        }

        rb.linearVelocity = transform.up * speed;
        Vector3 direction = currentTarget.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    private void SwitchTarget()
    {
        if (currentTarget == waypointA)
        {
            currentTarget = waypointB;
        }
        else
        {
            currentTarget = waypointA;
        }
        Debug.Log("Is close to target " + currentTarget);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Recognises if rocket hits PlayerController class collider
        if (otherCollider.GetComponent<PlayerController>() != null)
        {
            //Call Health class to deal damage to health bar
            Health playerHealth = otherCollider.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Health health = GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(int.MaxValue);
            }
        }
    }

    public void Deactivate()
    {
        soundLoopManager.Stop();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        spawn.currentMinion = 0;
    }

}