using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Showhighscore : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text Text;
    [SerializeField] int Level;
    float time;
    int timeint;
    // Start is called before the first frame update
    void Start()
    {
        time = PlayerPrefs.GetFloat("Level"+(Level+1));
        time *= 100;
        timeint = Mathf.RoundToInt(time);
        time = timeint / 100f;
        Text.text = "Highscore: " + time;
    }
    
    
}
