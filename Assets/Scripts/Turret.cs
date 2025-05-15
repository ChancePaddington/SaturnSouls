using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [Range (0f, 3f)]
    [SerializeField] private float laserTimer = 2f;
    //private GameObject player;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private Transform firingPoint;

    //Tutorial UI
    public TextMeshProUGUI tutorialText;

    private void Start()
    {
        //Contols the amount of time between laser shots
        StartCoroutine(Shoot(laserTimer));

        //player = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator Shoot(float timePeriod)
    {
        while (true)
        {
            //Spawns rocket
            Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
            //Suspends the coroutine for set amount of seconds
            yield return new WaitForSeconds(timePeriod);
        }
    }
    public void Deactivate()
    {
        //Destroy(tutorialText);
        Destroy(gameObject);
    }

}
