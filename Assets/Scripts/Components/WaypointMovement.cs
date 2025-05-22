using System;
using System.Collections;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    //Behaviour variables
    [Range(1, 20)]
    [SerializeField] private float speed = 20f;

    //Waypoint variables
    public float waitingAtWaypoint = 3f;
    public GameObject waypointA;
    public GameObject waypointB;
    private GameObject currentTarget;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;

        //Finds the game object with the tag to move to 
        //waypointA = GameObject.FindGameObjectWithTag("Minion Waypoint A");
        //waypointB = GameObject.FindGameObjectWithTag("Minion Waypoint B");

        Vector3 direction = waypointA.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

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

}
