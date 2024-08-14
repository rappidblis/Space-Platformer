using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public bool hasdied;
    Vector3 startpos;
    Quaternion startrot;
    
    private void Start()
    {
        startpos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            transform.position = startpos;
            hasdied = true;
            transform.rotation = startrot;
        }
    }
    
    public bool Hasdiedcheck()
    {
        if (hasdied)
        {
            hasdied = false;
            return true;
        }
        else { return false; }
       
        
    }

    public void setrespawnpos(Transform pos,Quaternion _rotation)
    {
        startpos= pos.position;
        startrot= pos.rotation;
    }




}
