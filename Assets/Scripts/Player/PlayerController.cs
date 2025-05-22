using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

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
    //[Range(0, 5)]
    [SerializeField] public float maxAmmo = 5;
    [Range(0, 10)]
    [SerializeField] public float reloadTime = 10f;
    private float currentAmmo;
    private bool isReloading = false;
    public Image ammoCapacity;
    private float ammoIsEmpty = 0f;

    public int gameOver;

    //Shield class
    [SerializeField] private Shield shield;

    //Health class
    [SerializeField] private Health health;

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        //Debug.Log("I have been touched");  
        //Debug.Log(collision.gameObject.name);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentAmmo = maxAmmo;
    }

    private void Update()

    {
        //Set movement speed on the X and Y axis
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        rb.AddForce(transform.up * thrust * rb.linearVelocity);

        //Rotates playercontroller towards mouse screen position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.LookAt(mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);

        //Create a bool to talk with Shield class re: shield regen
        HandleShieldInput();

        //Shoot upon left mouse click & is not reloading & ammo is greater than 0
        if (Input.GetMouseButtonDown(0) && !isReloading && currentAmmo > 0)
        {
            //Deduct ammo
            currentAmmo--;
            Shoot();
        }

        if (Input.GetMouseButtonDown(0) && !isReloading && currentAmmo <= 0) 
        {
            StartCoroutine(Reload());
        }

        ammoIsEmpty += Time.deltaTime;
        //The GUI radial fill amount
        ammoCapacity.fillAmount = 1f - (ammoIsEmpty / reloadTime);
        if (currentAmmo > 0)
        {
           ammoIsEmpty = 0f;
        }
        //Sets ammo GUI to current ammo
        //ammoCapacity.fillAmount = (float)currentAmmo / (float)maxAmmo;

        //if the current ammo is zero
        //count up the reload timer in seconds
        //The ammo capacity fill amount = reload timer / reload time

        //if the current ammo is greater than zero
        //reset the reload timer to zero;
        //the ammo capacity fill amount is equal to one

    }

    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        //Refill ammo
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public void HandleShieldInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shield.TryActivate();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            shield.Deactivate();
        }
    }

    public void Shoot()
    {
        Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
    }

    public void Deactivate()
    {
        Destroy(gameObject);
        TransitionToGameOverScene();
    }

    public void TransitionToGameOverScene()
    {
        SceneController.LoadScene(gameOver);
    }

}


 
