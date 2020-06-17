using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int bulletID;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("KillBullet", 3f);   
    }



    void KillBullet()
    {
        Destroy(gameObject);
    }
}
