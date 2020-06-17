using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class TriggerChecker : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Panel")
        {
            Debug.Log(other.transform.name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
