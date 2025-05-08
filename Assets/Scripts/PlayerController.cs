using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Mouse movement variables
    [SerializeField] private Camera mainCamera;
    private Vector2 mousePosition;

    //WASD movement variables
    private float moveSpeed = 5f;
    private float thrust = 2.0f;
    private Rigidbody2D rb;

    //Rocket variables
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;

    //Shield variables
    [SerializeField] private GameObject shieldSprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        shieldSprite.SetActive(false);
    }

    private void Update()

    {
        //Set movement speed on the X and Y axis
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        rb.AddForce(transform.up * thrust * rb.linearVelocity);

        //Alternatively, specify the force mode, which is ForceMode2D.Force by default
        //rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.LookAt(mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);


        //Shoot upon left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shieldSprite.SetActive(true);
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            shieldSprite.SetActive(false);
            Debug.Log("Shield off");
        }

    }
    public void Shoot()
    {
        Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
    }

}


 
