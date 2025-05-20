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

    private UIController uiCon;

    //Tutorial UI
    //public TextMeshProUGUI tutorialText;

    private void Start()
    {
        uiCon = FindAnyObjectByType<UIController>();
        //Contols the amount of time between laser shots
        StartCoroutine(Shoot(laserTimer));

    }

    private IEnumerator Shoot(float timePeriod)
    {
        while (true)
        {
            //Suspends the coroutine for set amount of seconds
            yield return new WaitForSeconds(timePeriod);
            //Spawns rocket
            Instantiate(rocketPrefab, firingPoint.position, firingPoint.rotation);
        }

    }
    
    public void Deactivate()
    {
        uiCon.enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
