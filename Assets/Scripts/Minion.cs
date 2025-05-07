using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    private GameObject waypointA;
    private GameObject waypointB;
    private Rigidbody2D rb;
    private Boss boss;
    private Vector2 currentTarget;
    public float force = 1.0f;
    public float waitingAtWaypoint = 3f;
    private bool currentWaypoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        //Finds the game object with the tag to move to
        waypointA = GameObject.FindGameObjectWithTag("Minion Waypoint A");
        waypointB = GameObject.FindGameObjectWithTag("Minion Waypoint B");

        boss = FindAnyObjectByType<Boss>();

        Vector3 direction = waypointA.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    public void Update()
    {
        //Get the distance between the minion and the waypoint
        float distanceToTarget = Vector3.Distance(transform.position, waypointA.transform.position);

        //If this is within a threshold (e.g. 0.1f)
        bool isCloseToTarget = distanceToTarget < 0.2f;

        //We have arrived! So set the linear velocity to zero
        if (isCloseToTarget)
        {
            rb.linearVelocity = Vector2.zero;

            StartCoroutine(SwitchTargetPosition(waitingAtWaypoint));
        }

    }

    public IEnumerator SwitchTargetPosition(float timePeriod)
    {
        float distanceToTargetA = Vector3.Distance(transform.position, waypointA.transform.position);
        bool isCloseToTargetA = distanceToTargetA < 0.2f;

        if (isCloseToTargetA)
        {
            yield return new WaitForSeconds(timePeriod);
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.up * speed;
            Vector3 direction = waypointB.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        }


        float distanceToTargetB = Vector3.Distance(transform.position, waypointB.transform.position);
        bool isCloseToTargetB = distanceToTargetB < 0.2f;

        if (isCloseToTargetB)
        {
            yield return new WaitForSeconds(timePeriod);
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.up * speed;
            Vector3 direction = waypointA.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        }

    }
    private void OnDestroy()
    {
        boss.currentMinion = 0; 
    }
}

    //Get minion to move between waypoints

    //When the minion is destroyed, talk to the Boss script and tell it that the current minion now has no value
    //Global and local varible