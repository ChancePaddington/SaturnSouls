using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
    public Turret turret;
    public MinionSpawn spawn;

    //Waypoint variables
    public float waitingAtWaypoint = 3f;
    public GameObject waypointA;
    public GameObject waypointB;

    //Audio
    [SerializeField] AudioClip alarmSound;
    public SoundLoopManager soundLoopManager;
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

        Vector3 direction = waypointA.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        //Play audio
        //SoundManager.instance.PlayLoopFXClip(alarmSound, transform, volume);

        Destroy(gameObject, lifeTime);

    }

    public void Update()
    {
        StartCoroutine(SwitchTargetPosition(waitingAtWaypoint));

    }

    //for (int i = 0; i < waypoints.Count; i++)
    public IEnumerator SwitchTargetPosition(float timePeriod)
    {
        // iterate across the list
        MoveToTarget();
        yield return new WaitForSeconds(timePeriod);

    }


    public void MoveToTarget()
    {
        float distanceToTargetA = Vector3.Distance(transform.position, waypointA.transform.position);
        bool isCloseToTargetA = distanceToTargetA < 0.2f;

        if (isCloseToTargetA)
        {
            //yield return new WaitForSeconds(timePeriod);
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.up * speed;
            Vector3 direction = waypointB.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

        }

        float distanceToTargetB = Vector3.Distance(transform.position, waypointB.transform.position);
        bool isCloseToTargetB = distanceToTargetB < 0.2f;

        if (isCloseToTargetB)
        {
            Debug.Log("Needs to wait");
            //yield return new WaitForSeconds(timePeriod);
            Debug.Log("Has waited");
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.up * speed;
            Vector3 direction = waypointA.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Recognises if rocket hits PlayerController class collider
        if (otherCollider.GetComponent<PlayerController>() != null)
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

    public void Deactivate()
    {
        //Destroy(soundLoopManager.audioSource);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        spawn.currentMinion = 0;
    }

}