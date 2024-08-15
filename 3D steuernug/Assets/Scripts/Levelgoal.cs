using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lEVELGOAL : MonoBehaviour
{
    [SerializeField] string nextlvl;
    [SerializeField] UImanager uimanager;
    bool cancontinue;
    float endtime;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endtime = uimanager.GetTime();
            if (!PlayerPrefs.HasKey("Level" + SceneManager.GetActiveScene().buildIndex))//falls es kein highscore gibt
            {
                PlayerPrefs.SetFloat("Level" + SceneManager.GetActiveScene().buildIndex, endtime);
            }
            else if (PlayerPrefs.GetFloat("Level" + SceneManager.GetActiveScene().buildIndex) > endtime)//wenn man einen neuen highscore hat
            {
                PlayerPrefs.SetFloat("Level" + SceneManager.GetActiveScene().buildIndex, endtime);
            }
            PlayerPrefs.SetFloat("endtime", endtime);
            PlayerPrefs.SetInt("nextscene", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("Endscreen");
            
            //wait for secconds
            
            
            
           
        }

    }
    

}
