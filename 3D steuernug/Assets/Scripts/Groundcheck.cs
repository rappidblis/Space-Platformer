using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{

    [SerializeField] Playermovement Playermovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerStay(Collider _other)
    {
        if (_other.CompareTag("Level"))
        {
            Playermovement.isgroundedtrue();
        }
    }
}
