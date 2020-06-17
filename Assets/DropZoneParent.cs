using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneParent : MonoBehaviour
{

    public TextBlock spawnBlock;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("getSpawnBlock", .1f);
    }

    public void getSpawnBlock()
    {
        //Debug.Log(transform.GetChild(0).name);
       // Debug.Log(transform.GetChild(0).GetChild(1).name);

        foreach(Transform trans in transform.GetChild(0))
        {
            Debug.Log(trans.name);
        }

        spawnBlock = transform.GetChild(0).GetChild(1).GetComponent<TextBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
