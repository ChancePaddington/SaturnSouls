using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Image shieldRecharge;
    public Health health;   

    [Range(0f, 5f)]
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

        timeSinceDeactivation += Time.deltaTime;
        //The radial fill amount = 1f - (timeSinceDeactivation / cooldown)
        shieldRecharge.fillAmount = 1f - (timeSinceDeactivation / cooldown);

        // same as "timeSinceDeactivation = timeSinceDeactivation + Time.deltaTime;"

        if (timeSinceDeactivation >= cooldown)
        {
            RegenerateShield();
        }
    }

    private void RegenerateShield()
    {
        canActivate = true;
        shieldRecharge.fillAmount = 1f;
        health.ResetToMax();
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
        GetComponent<CircleCollider2D>().enabled = enabled;

    }
}
