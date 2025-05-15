using System.Collections;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI movement;
    public TextMeshProUGUI shooting;
    public TextMeshProUGUI shield;

    private float textTiming = 3f;

    private void Update()
    {
        DestroyMovementText();
        DestroyShootingText();
        DestroyShieldText();
    }

    private void DestroyMovementText()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(MovementTimer(textTiming));
        }
    }

    private IEnumerator MovementTimer(float timePeriod)
    {
        yield return new WaitForSeconds(timePeriod);
        Destroy(movement);
    }

    private void DestroyShootingText()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootingTimer(textTiming));
        }
    }

    private IEnumerator ShootingTimer(float timePeriod)
    {
        yield return new WaitForSeconds(timePeriod);
        Destroy(shooting);
    }

    private void DestroyShieldText()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShieldTimer(textTiming));
        }
    }

    private IEnumerator ShieldTimer(float timePeriod)
    {
        yield return new WaitForSeconds(timePeriod);
        Destroy(shield);
    }

}
