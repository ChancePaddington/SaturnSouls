using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject playerShip;
    public Renderer shield;
    public Collider2D shieldCollider;

    //Shield variables
    public int currentHealth;
    public int maxHealth  = 50;
    public float damageToShield;
    public float regenPerSec = 0.1f;
    public bool shieldUp = false;
    private int energy = 100;
    private int damage = 5;

    private void Start()
    {
        shield = GetComponent<SpriteRenderer>();
        shieldCollider = GetComponent<Collider2D>();

    }

    private void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
      
    }

}
