using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block" || other.gameObject.tag == "Cannon")
        {
            //Debug.Log(other.transform.position);



            //Debug.Log("Object hit the floor");
            //Play audio of explosion
            //Trigger particle effect
            Destroy(other.gameObject);
        }

            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
