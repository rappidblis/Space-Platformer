using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Death death;
    [SerializeField] float timeatrespawn;
    [SerializeField] UImanager uimanager;
    bool reachedrespawn;
    private void OnTriggerEnter(Collider other)
    {
        death = other.GetComponent<Death>();
        death.setrespawnpos(other.transform,other.transform.rotation);
        PlayerPrefs.SetFloat("timeatrespawn",uimanager.GetTime());

    }
    private void Update()
    {
        
    }

    




}

