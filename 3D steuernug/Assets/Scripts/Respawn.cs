using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Death death;
    [SerializeField] float timeatrespawn;
    bool reachedrespawn;
    private void OnTriggerEnter(Collider other)
    {
        death = other.GetComponent<Death>();
        death.setrespawnpos(other.transform,other.transform.rotation);
        reachedrespawn = true;
        
    }
   



}

