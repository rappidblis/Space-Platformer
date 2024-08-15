using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Endscreenscript : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text text;
    string endtime;
    // Start is called before the first frame update
    void Start()
    {
        endtime = PlayerPrefs.GetFloat("endtime").ToString();
        text.text = "Congratulations!\nYour time is: " + endtime[0] + endtime[1] + endtime[2]+ endtime[3];
        Invoke("nextscene", 3);

            


    }
    void nextscene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("nextscene"));
    }
}
