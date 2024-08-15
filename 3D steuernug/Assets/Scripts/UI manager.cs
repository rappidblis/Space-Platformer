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
    string timestring;
    [SerializeField] TMPro.TMP_Text timer;
    // Start is called before the first frame update
    private void Start()
    {
        PlayerPrefs.SetFloat("timeatrespawn", 0);
    }

    // Update is called once per frame
    void Update()
    {
        speedint = Mathf.RoundToInt(Mathf.Abs(playerRB.velocity.x) + Mathf.Abs(playerRB.velocity.z));
        speed.text = speedint.ToString();
        time += Time.deltaTime;
        timestring = time.ToString();
        timer.text = "Time:" + timestring[0] + timestring[1] + timestring[2] + timestring[3];
        if (playerRB.gameObject.GetComponent<Death>().Hasdiedcheck())
        {
            //wie fixxe ich das
            time = 0+PlayerPrefs.GetFloat("timeatrespawn");
        }
    }
    
    public float GetTime()
    {
         return time;
    }

   
    
    
    
}
    



