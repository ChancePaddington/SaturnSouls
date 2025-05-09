using UnityEngine;

public class Timer : MonoBehaviour
{
    public float targetTime = 600.0f;

    private void Start()
    {
      //When level begins
    }

    private void Update()
    {
        targetTime = Time.deltaTime;

        if (targetTime <= 0 )
        {
            //Game Over screen
        }
    }

}
