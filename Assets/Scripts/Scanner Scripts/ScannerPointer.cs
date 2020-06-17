using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ScannerPointer : MonoBehaviour
{
    public CheckScanObject scanner;
    public VRTK_Pointer pointer;
    GameObject scannObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pointer.pointerRenderer.GetDestinationHit().transform != null)
        {
            if(pointer.pointerRenderer.GetDestinationHit().transform.gameObject.GetComponent<ObjectAccesor>() != null)
            {
                ObjectAccesor accesor = pointer.pointerRenderer.GetDestinationHit().transform.gameObject.GetComponent<ObjectAccesor>();
                scanner.setText(accesor.scanAttributes);
            }
            //Debug.Log(pointer.pointerRenderer.GetDestinationHit().transform.name);

        
        }
        
    }
}
