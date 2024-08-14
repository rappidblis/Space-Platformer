using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermovement : MonoBehaviour
{
    public Vector3 inputvector;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] int speed;
    [SerializeField] Transform cam;
    [SerializeField] float speedH = 2.0f;
    [SerializeField] float speedV = 2.0f;
    [SerializeField] float jumpheight;
    [SerializeField] private bool isgrounded;
    [SerializeField] float gravity;
    [SerializeField] int decelaration;
    bool verticalinput;
    bool horizontalinput;

    [SerializeField] Canvas pausemenu;
    bool pause;

    
    

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pausemenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Cursor.lockState = CursorLockMode.None;
            pausemenu.enabled = true;
        }
        if (pause)
        {
            return;
        }
        inputvector = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        inputvector.Normalize();
        
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        float clampedX = Mathf.Clamp(pitch, -85, 85);

        if (isgrounded && Input.GetAxis("Jump")!=0)
        {
            playerRB.AddForce(0, jumpheight, 0, ForceMode.Impulse);
            isgrounded = false;
        }

        cam.eulerAngles = new Vector3(clampedX, yaw, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
    public void isgroundedtrue()
    {
        isgrounded = true;
    }
    private void FixedUpdate()
    {
        Vector3 targetvel = ((transform.forward * inputvector.z) + (transform.right * inputvector.x))*speed;

        playerRB.AddForce(targetvel);
        if (!isgrounded)
        {
            playerRB.AddForce(Vector3.down * gravity);
        }
        
        
    }
    public bool IsGrounded()
    {
        return isgrounded;
    }
    public void Setisgroundedfalse()
    {
        isgrounded = false;
    }
    public void resumegame()
    {
        pausemenu.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    


}
