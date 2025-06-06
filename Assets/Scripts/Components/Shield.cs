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
    private float timeSinceDeactivation = Mathf.Infinity;

    //Audio
    [SerializeField] AudioClip rechargeSound;
    [Range(1, 10)]
    [SerializeField] float volume = 1f;

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
        SoundManager.instance.PlaySoundFXClip(rechargeSound, transform, volume);
    }

    public void TryActivate()
    {
        if (canActivate)
        {
            Activate(true);
        }
    }

    public void Disable()
    {
        timeSinceDeactivation = 0f;
        canActivate = false;
        Deactivate();
    }

    public void Deactivate()
    {
        if (!isActive) { return; }
        Activate(false);
    }

    private void Activate(bool enabled)
    {
        isActive = enabled;
        GetComponent<SpriteRenderer>().enabled = enabled;
        GetComponent<CircleCollider2D>().enabled = enabled;

    }
}
