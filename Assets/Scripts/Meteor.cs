using System.Collections;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Rigidbody2D rb;
    public Boss boss;
    private GameObject waypointA;
    private GameObject waypointB;
    private GameObject waypointC;
    private GameObject waypointD;
    private GameObject player;
    private float waitingAtWaypoint = 5f;
    public int currentMeteor;

    //Behaviour variables
    [Range(1, 20)]
    [SerializeField] private float speed = 20f;
    [Range(1, 20)]
    [SerializeField] private float lifeTime = 20f;
    public int damage = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;
        player = GameObject.FindGameObjectWithTag("Player");
        //Finds the game object with the tag to move to
        //(For later) Add to boss family and call from the boss class 
        waypointA = GameObject.FindGameObjectWithTag("Meteor Waypoint A");
        waypointB = GameObject.FindGameObjectWithTag("Meteor Waypoint B");
        waypointC = GameObject.FindGameObjectWithTag("Meteor Waypoint C");
        waypointD = GameObject.FindGameObjectWithTag("Meteor Waypoint D");


        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = waypointA.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        Destroy(gameObject, lifeTime);
    }

    public void Update()
    {
        //Controls the time between position changes
        StartCoroutine(SwitchTargetPosition(waitingAtWaypoint));
    }

    public IEnumerator SwitchTargetPosition(float timePeriod)
    {
    
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
            Vector3 direction = waypointC.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
        }

        float distanceToTargetC = Vector3.Distance(transform.position, waypointC.transform.position);
        bool isCloseToTargetC = distanceToTargetC < 0.2f;

        if (isCloseToTargetC)
        {
            Debug.Log("Needs to wait");
            //yield return new WaitForSeconds(timePeriod);
            Debug.Log("Has waited");
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.up * speed;
            Vector3 direction = waypointD.transform.position - transform.position;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;
        }

        float distanceToTargetD = Vector3.Distance(transform.position, waypointD.transform.position);
        bool isCloseToTargetD = distanceToTargetD < 0.2f;

        if (isCloseToTargetD)
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

        }
    }

    //private void OnDestroy()
    //{
    //    boss.currentMeteor = 0;
    //}
}
