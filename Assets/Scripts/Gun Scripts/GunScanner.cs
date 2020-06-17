using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GunScanner : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public GameObject firePoint;

    public GameObject scannedObject;

    public ifScanObject scanObjectScript;

    public VRTK_ControllerEvents controllerEvents;

    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;

        controllerEvents.TriggerClicked += ControllerEvents_TriggerClicked;
        controllerEvents.TriggerPressed += ControllerEvents_TriggerPressed;

        controllerEvents.TriggerReleased += ControllerEvents_TriggerReleased;
    }

    private void ControllerEvents_TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        laserLineRenderer.enabled = false;

    }

    private void ControllerEvents_TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        laserLineRenderer.enabled = true;
        ShootLaserFromTargetPosition(firePoint.transform.position, firePoint.transform.forward, laserMaxLength);
        if(scannedObject != null)
        {
            scanObjectScript.scannedObject = scannedObject.GetComponent<ObjectAccesor>().scanAttributes;
            scanObjectScript.CheckCompare();
        }
        
    }

    private void ControllerEvents_TriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        laserLineRenderer.enabled = true;
        ShootLaserFromTargetPosition(firePoint.transform.position, firePoint.transform.forward, laserMaxLength);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            ShootLaserFromTargetPosition(firePoint.transform.position, firePoint.transform.forward, laserMaxLength);
            laserLineRenderer.enabled = true;
        }
        else
        {
            laserLineRenderer.enabled = false;
        }
        */
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
            

            if(raycastHit.transform.tag == "Scannable" && raycastHit.transform.GetComponent<ObjectAccesor>() != null)
            {
                
                scannedObject = raycastHit.transform.gameObject;

                Debug.Log("Scannable: " + raycastHit.transform.name);
            }
            else
            {
                scannedObject = null;
            }
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }



}
