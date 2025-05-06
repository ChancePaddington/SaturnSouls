using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private Transform shieldSpawn;

    private SpriteRenderer shield;

    private void Start()
    {
        shield = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Shield"))
        {
            ActivateShield();
        }
    }

    public void ActivateShield()
    {

    }
}
