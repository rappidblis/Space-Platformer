using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using TMPro;
using UnityEngine.UI;


public class UImanager : MonoBehaviour
{
    [SerializeField] Rigidbody playerRB;
    [SerializeField] TMPro.TMP_Text speed;
    int speedint;
    float time;
    Death playerdeath;
    bool death;
    string timestring;
    [SerializeField] TMPro.TMP_Text timer;
    // Start is called before the first frame update
    private void Start()
    {
        time = 0;
        playerdeath = playerRB.GetComponent<Death>();

    }

    // Update is called once per frame
    void Update()
    {
        speedint = Mathf.RoundToInt(Mathf.Abs(playerRB.velocity.x) + Mathf.Abs(playerRB.velocity.z));
        speed.text = speedint.ToString();
        time += Time.deltaTime;
        timestring = time.ToString();
        timer.text = "Time:" + timestring[0] + timestring[1] + timestring[2] + timestring[3];
        if (playerdeath.Hasdiedcheck())
        {
            
            time = 0;
        }
        

    }
    
    public float GetTime()
    {
         return time;
    }
    
}
    



