using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 6f;
    //[SerializeField] private List<GameObject> waypoints = new List<GameObject>();

    private Rigidbody2D rb;
    private Boss boss;
    public int damage = 10;
    //public MinionWaypoints minionWaypoints;
   // private Vector2 currentTarget;
    public float force = 1.0f;
    public float waitingAtWaypoint = 3f;
    public GameObject waypointA;
    public GameObject waypointB;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        //Finds the game object with the tag to move to
        //(For later) Add to boss family and call from the boss class 
        waypointA = GameObject.FindGameObjectWithTag("Minion Waypoint A");
        waypointB = GameObject.FindGameObjectWithTag("Minion Waypoint B");

        boss = FindAnyObjectByType<Boss>();
        //minionWaypoints = GetComponent<MinionWaypoints>();

        Vector3 direction = waypointA.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        Destroy(gameObject, lifeTime);

        //foreach (var waypoint in GetComponent<MinionWaypoints>().waypoints)
        //{
        //    waypoints.Add(waypoint);
        //}

    }

    public void Update()
    {
        StartCoroutine(SwitchTargetPosition(waitingAtWaypoint));

        //Get the distance between the minion and the waypoint
        //float distanceToTarget = Vector3.Distance(transform.position, waypoint.transform.position);

        ////If this is within a threshold (e.g. 0.1f)
        //bool isCloseToTarget = distanceToTarget < 0.2f;

        ////We have arrived! So set the linear velocity to zero
        //if (isCloseToTarget)
        //{
        //    rb.linearVelocity = Vector2.zero;

        //}
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
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

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
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
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

    private void OnDestroy()
    {
        boss.currentMinion = 0; 
    }

}
    //    float distanceToCurrentTarget = Vector3.Distance(transform.position, waypoint.transform.position);
    //    bool isCloseToCurrentTarget = distanceToCurrentTarget < 0.2f;
    //    bool isCloseToNextTarget = distanceToCurrentTarget > 0.2f;
    //    // think of if statement for transitioning from last waypoint back to the beginning
    //    if (isCloseToCurrentTarget)
    //    {
    //        rb = GetComponent<Rigidbody2D>();

        //        rb.linearVelocity = transform.up * speed;
        //        Vector3 direction = waypoint.transform.position - transform.position;
        //        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        //        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        //        transform.rotation = Quaternion.Euler(0, 0, rot);
        //    }

        //    if (isCloseToNextTarget)
        //    {
        //        rb.linearVelocity = Vector2.zero;
        //    }
        //}



    //}

//}

    //Get minion to move between waypoints

    //When the minion is destroyed, talk to the Boss script and tell it that the current minion now has no value
    //Global and local varible