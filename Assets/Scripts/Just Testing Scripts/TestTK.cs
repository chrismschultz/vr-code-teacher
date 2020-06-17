using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not really used that much, this was just me testing stuff
namespace VRTK
{
public class TestTK : MonoBehaviour
{
    // Start is called before the first frame update
    VRTK.VRTK_PolicyList policyList;

    public VRTK.VRTK_ControllerEvents events;

    public VRTK.VRTK_SnapDropZone snapZone;

    public List<GameObject> snapObjects;

    GameObject currentSnap;

    void Start()
    {
      snapObjects = new List<GameObject>();
      currentSnap = new GameObject();

      snapZone.ObjectEnteredSnapDropZone += new SnapDropZoneEventHandler(ObjectEnteredEvent);
      snapZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedInto);
      


    }

    // Update is called once per frame
    void Update()
    {
      if(events.triggerClicked || Input.GetKeyDown(KeyCode.Space))
      {
          Debug.Log("TREIGGER HAS BEEN PRESSED");
      }  
      
      if(events.touchpadPressed)
      {
        if(snapZone.GetCurrentSnappedObject() != null)
         {
           snapObjects.Clear();
           getSnapObjects();
         }
      }
    }



  public void getSnapObjects()
  {
    //Check if something is in the snap zone
    if(snapZone.GetCurrentSnappedObject() != null)
    {
      //Get the object that is currently in the snap zone 
      currentSnap = snapZone.GetCurrentSnappedObject();

      //Add it to the list of snapped objects 
      if(snapObjects.Contains(currentSnap) == false)
      {
        snapObjects.Add(currentSnap);
      }
      //Iterate through other snapped objects
      while(currentSnap != null)
      {
        //Only add object to list if it is not in there already
        if(snapObjects.Contains(currentSnap) == false)
        {
          snapObjects.Add(currentSnap);
        }
        //Iterate through the children.
        currentSnap = currentSnap.GetComponentInChildren<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();

      }
    }

  }

    private void ObjectEnteredEvent(object sender, SnapDropZoneEventArgs e)
    {
      VRTK_Logger.Info("Entered Snap Area");
    }

    private void ObjectSnappedInto(object sender, SnapDropZoneEventArgs e)
    {
      VRTK_Logger.Info("Fully Snapped " + e.snappedObject.name);
    }

}
}

