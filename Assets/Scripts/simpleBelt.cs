using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleBelt : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    public float speed;

    private void OnTriggerStay(Collider other)
    {
        //other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
        if(other.tag == "Block")
        {
            float conveyorVelocity = speed * Time.deltaTime;
            Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            rigidbody.velocity = conveyorVelocity * transform.right;
        }
        
    }
}
