using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallpunch : MonoBehaviour
{
    [SerializeField] Rigidbody playerRB;
    [SerializeField] float wallpunchstr;
    [SerializeField] float verticalJumpforce;
    bool inputforhorizontal;
    bool inputforvertical;
    bool isgrounded;
    bool canrightclickinair;
    [SerializeField] Playermovement playermovscript;
    [SerializeField] AudioClip rightclicksound;
    [SerializeField] AudioClip leftclicksound;
    AudioSource AudioSource;

    private void Start()
    {
         AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = playermovscript.IsGrounded();
        if (isgrounded)
        {
            canrightclickinair = true;
        }
        if (Input.GetAxis("Fire2") == 1)
        {
            inputforvertical = true;
            
        }
        else
        {
            inputforvertical = false;
        }
        if (Input.GetAxis("Fire1") == 1)
        {
            inputforhorizontal = true;
           
        }
        else
            inputforhorizontal = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Level") == false)
            return;

        
        if (inputforhorizontal)
        {
            playerRB.AddForce(-transform.forward * wallpunchstr,ForceMode.Impulse);
            AudioSource.clip = leftclicksound;
            AudioSource.Play();
        }
        if (inputforvertical && isgrounded)
        {
            playerRB.velocity = Vector3.zero;
            playerRB.AddForce(new Vector3(-transform.forward.x,1,-transform.forward.z)* verticalJumpforce, ForceMode.Impulse);
            playermovscript.Setisgroundedfalse();
            AudioSource.clip = rightclicksound;
            AudioSource.Play();
        }
        if (inputforvertical && !isgrounded && canrightclickinair)
        {
            playerRB.velocity = Vector3.zero;
            playerRB.AddForce(new Vector3(-transform.forward.x, 1, -transform.forward.z)* verticalJumpforce, ForceMode.Impulse);
            canrightclickinair = false;
            AudioSource.clip = rightclicksound;
            AudioSource.Play();
        }
               
        
    }
}
