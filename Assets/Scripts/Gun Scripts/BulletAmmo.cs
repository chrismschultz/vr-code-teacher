using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletAmmo : MonoBehaviour
{
    public int ammoID;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        Gun gun = other.GetComponentInParent<Gun>();

        if (gun != null)
        {
            Debug.Log("Changing Ammo");
            gun.bulletIndex = ammoID;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
