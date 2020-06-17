using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class LeverManager : MonoBehaviour
{
    public VRTK_PhysicsRotator rotator;

    public float leverValue;

    public bool leverBool;

    // Start is called before the first frame update
    void Start()
    {
        rotator = GetComponentInChildren<VRTK_PhysicsRotator>();   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Get Value " + rotator.GetValue().ToString("F1"));
        Debug.Log("Get Step Value " + rotator.GetStepValue(rotator.GetValue()));

        leverValue = rotator.GetStepValue(rotator.GetValue());

        if(leverValue == 1 || leverValue == -1)
        {
            leverBool = true;
        }
        else
        {
            leverBool = false;
        }

    }
}
