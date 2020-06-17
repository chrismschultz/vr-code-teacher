using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

//NOT NEEDED LOOK AT GunScanner
public class ifScanner : MonoBehaviour
{
    public VRTK_Pointer pointer;
    GameObject scannObject;
    public ifScanObject ifScan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pointer.pointerRenderer.GetDestinationHit().transform != null)
        {
            if (pointer.pointerRenderer.GetDestinationHit().transform.gameObject.GetComponent<ObjectAccesor>() != null)
            {
                ObjectAccesor accesor = pointer.pointerRenderer.GetDestinationHit().transform.gameObject.GetComponent<ObjectAccesor>();
                ifScan.scannedObject =  accesor.scanAttributes;
                ifScan.CheckIndex();
                ifScan.CheckCompare();
               
            }
        }

    }
}
