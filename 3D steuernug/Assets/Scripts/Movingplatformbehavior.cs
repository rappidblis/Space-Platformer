using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatformbehavior : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] int speed;
    int value;
    BoxCollider carryzone;

    private void Start()
    {
        carryzone = GetComponentInChildren<BoxCollider>();
    }
    private void FixedUpdate()
    {
        if (transform.position.x >= waypoints[value].position.x - 0.3 && transform.position.x <= waypoints[value].position.x + 0.3)
            if (transform.position.y >= waypoints[value].position.y - 0.3 && transform.position.y <= waypoints[value].position.y + 0.3)
                if (transform.position.z >= waypoints[value].position.z - 0.3 && transform.position.z <= waypoints[value].position.z + 0.3)
                    if (value == waypoints.Count-1)
                        value = 0;
                    else
                        value++;
        transform.position += Vector3.Normalize(waypoints[value].position - transform.position)/100 *speed;
            
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }





}
