using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionWaypoints : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;
    [SerializeField] public List<GameObject> waypoints = new List<GameObject>();

    /*private Rigidbody2D rb;
    public float force = 1.0f;
    public float waitingAtWaypoint = 3f;

    public void Start()
    {
        StartCoroutine(SwitchTargetPosition(waitingAtWaypoint));
    }

    public IEnumerator SwitchTargetPosition(float timePeriod)
    {

        for (int i = 0; i < waypoints.Count; i++)
        {
            // iterate across the list
            MoveToTarget(waypoints[i]);
            yield return new WaitForSeconds(timePeriod);
        }
    }
    public void MoveToTarget(GameObject waypoint)
    {
        float distanceToCurrentTarget = Vector3.Distance(transform.position, waypoint.transform.position);
        bool isCloseToCurrentTarget = distanceToCurrentTarget < 0.2f;
        bool isCloseToNextTarget = distanceToCurrentTarget > 0.2f;
        // think of if statement for transitioning from last waypoint back to the beginning
        if (isCloseToCurrentTarget)
        {
            rb = GetComponent<Rigidbody2D>();

            rb.linearVelocity = transform.up * speed;
            Vector3 direction = waypoint.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }

        if (isCloseToNextTarget)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }*/
}
