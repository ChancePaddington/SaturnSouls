using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float cooldown = 1f;

    private bool isActive = false;
    private bool canActivate = true;
    private float timeSinceDeactivation = 0f;

    private void Start()
    {
        Activate(false);
    }

    private void Update()
    {
        if (canActivate) { return; }

        //Debug.Log($"delta time: {Time.deltaTime} - time since deactivation: {timeSinceDeactivation}");

        timeSinceDeactivation += Time.deltaTime;
        // same as "timeSinceDeactivation = timeSinceDeactivation + Time.deltaTime;"

        if (timeSinceDeactivation >= cooldown)
        {
            canActivate = true;
        }
    }

    public void TryActivate()
    {
        if (canActivate)
        {
            Activate(true);
        }
    }

    public void DeactivateWithCooldown()
    {
        timeSinceDeactivation = 0f;
        Deactivate();
    }

    public void Deactivate()
    {
        if (!isActive) { return; }

        canActivate = false;
        Activate(false);
    }

    private void Activate(bool enabled)
    {
        isActive = enabled;
        GetComponent<SpriteRenderer>().enabled = enabled;
        GetComponent<BoxCollider2D>().enabled = enabled;
    }
}
