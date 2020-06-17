using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class LeverTrigger : MonoBehaviour
{
    public VRTK_PhysicsRotator rotator;

    public float leverValue;

    public bool leverBool;

    public bool sendMessage;

    // Start is called before the first frame update
    void Start()
    {
        rotator = GetComponentInChildren<VRTK_PhysicsRotator>();
        sendMessage = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Get Value " + rotator.GetValue().ToString("F1"));
        //Debug.Log("Get Step Value " + rotator.GetStepValue(rotator.GetValue()));

        leverValue = rotator.GetStepValue(rotator.GetValue());

        //rotator.MaxLimitReached += Rotator_MaxLimitReached;
        //rotator.MinLimitReached += Rotator_MinLimitReached;
        //rotator.MaxLimitExited += Rotator_MaxLimitReached;

        

        if (leverValue == 1 || leverValue == -1)
        {
            leverBool = true;
        }
        else
        {
            leverBool = false;
        }

    }

    private void Rotator_MinLimitReached(object sender, VRTK.Controllables.ControllableEventArgs e)
    {
       // Debug.Log("MIN LIMIT EXITED");
    }

    private void Rotator_MaxLimitReached(object sender, VRTK.Controllables.ControllableEventArgs e)
    {
       // Debug.Log("MAX LIMIT EXITED");
    }

    public void SendMessage()
    {
        if(sendMessage)
        {
            Debug.Log("Get Step Value " + rotator.GetStepValue(rotator.GetValue()));
            sendMessage = false;
        }
    }

}
