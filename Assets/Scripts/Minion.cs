using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    private GameObject waypoint;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float force = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        //Finds the game object with the tag to move to
        waypoint = GameObject.FindGameObjectWithTag("Minion Waypoint");

        Vector3 direction = waypoint.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }
    //public void SetMovement(int x, int y)
    //{
    //    SetMovement(new Vector2(x, y)); 
    //}

    //private void StopMovement()
    //{
    //   SetMovement(new Vector2(0,0));
    //}


    private void Update()
    {
        //Get the distance between the minion and the waypoint

        //If this is within a threshold (e.g. 0.1f)

        //We have arrived! So set the linear velocity to zero




        //if (transform.position == waypoint.transform.position)
        //{
        //    StopMovement();
        //    Debug.Log("StopeMovement in IF");
        //}
    }

}
