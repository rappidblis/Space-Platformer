using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanishingplatform : MonoBehaviour
{
    bool trigger;
    [SerializeField] Animator anim;
    [SerializeField] Collider col;
    [SerializeField] float vanishingtime;
    [SerializeField] float cooldowntime;
    [SerializeField] float vanishingtimer;
    [SerializeField] float cooldowntimer;
    private void Start()
    {
        trigger = false;
        vanishingtimer = vanishingtime;
        cooldowntimer = cooldowntime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        trigger = true;
        anim.SetBool("Trigger", true);
    }
    private void FixedUpdate()
    {
        if (trigger)
        {
            vanishingtimer -= Time.deltaTime;
        }
        if (vanishingtimer <=0)
        {
            col.enabled = false;
            cooldowntimer -= Time.deltaTime;
            anim.SetBool("Regenerating", true);
        }
        if (cooldowntimer <=0)
        {
            vanishingtimer = vanishingtime;
            cooldowntimer = cooldowntime;
            trigger = false;
            col.enabled = true;
            anim.SetBool("Trigger", false);
            anim.SetBool("Regenerating", false);
        }
        
    }


}
