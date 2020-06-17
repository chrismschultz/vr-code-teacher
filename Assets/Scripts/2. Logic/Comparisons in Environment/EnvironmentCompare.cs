using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCompare : MonoBehaviour
{
    public float val1;
    public float val2;

    public int compareID;

    // Start is called before the first frame update
    void Start()
    {
        compareValues();
    }


    public void compareValues()
    {
        if(val1 == val2)
        {
            compareID = 0;
            //Debug.Log("Val1 is equal val2");
        }
        else if(val1 < val2)
        {
            compareID = 1;
            //Debug.Log("Val1 is less than val2");
        }
        else
        {
            compareID = 2;
            //Debug.Log("Val1 is greater than val2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        compareValues();
    }
}
