using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionWaypoints : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float speed = 10f;
    [SerializeField] public List<GameObject> waypoints = new List<GameObject>();
           
}
