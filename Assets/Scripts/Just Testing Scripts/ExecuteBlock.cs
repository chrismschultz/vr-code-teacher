using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK
{
    public class ExecuteBlock : MonoBehaviour
    {
        public int snapCounter;
        public List<Transform> snapHolders;
        public List<VRTK_SnapDropZone> dropZones;

        public List<GameObject> snapObjects;

        // Start is called before the first frame update
        void Start()
        {
            foreach(Transform child in transform)
            {
                //Get the transform for the snapZones
                snapHolders.Add(child);
                //Get the actual dropZone component
                //This is so we dont have to do child.GetComponentInChildren<VRTK_SnapDropZone>() every time we want to talk to the dropZone script
                dropZones.Add(child.GetComponentInChildren<VRTK_SnapDropZone>());

                //Set the objects in the snap zones to null
                snapObjects.Add(null);

                //Disable the drop zones
                child.gameObject.SetActive(false);
            }

            foreach(VRTK_SnapDropZone zone in dropZones)
            {
                //Go through each of the drop zones and add a new event
                //depending on if an object was added or taken away
                zone.ObjectSnappedToDropZone+=new SnapDropZoneEventHandler(ObjectSnappedInto);
                zone.ObjectExitedSnapDropZone+=new SnapDropZoneEventHandler(ObjectExitedSnap);
            }
            
             snapCounter = 0;
            activateSnap(snapCounter);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        //If an object gets snapped into a DropZone
        private void ObjectSnappedInto(object sender, SnapDropZoneEventArgs e)
        {
            //Increment the total number of snaped objects
            snapCounter++;

            //Activate the zone after it
            activateSnap(snapCounter);
            //Iterate through all zones to see where objects are snapped to
            GetSnappedObjects();
        }

        //Objects were taken out of DropZone
        private void ObjectExitedSnap(object sender, SnapDropZoneEventArgs e)
        {
            //Go back and find out what zones have objects in them
            VRTK_Logger.Info("Exited Snap " + e.snappedObject.name + " " );
            GetSnappedObjects();
        }

        //When one object gets added we want to activate the drop zone after it
        public void activateSnap(int pos)
        {
            if(snapCounter < snapHolders.Count)
            {
                snapHolders[pos].gameObject.SetActive(true);
            }
            
        }

        //Iterate through all the drop zones and find what object is beinh snapped
        public void GetSnappedObjects()
        {
            for(int i = 0; i < dropZones.Count; i++)
            {
                if(dropZones[i].GetCurrentSnappedObject() == null)
                {
                    snapObjects[i] = null;
                }
                else
                {
                    snapObjects[i] = dropZones[i].GetCurrentSnappedObject().gameObject;
                }
                
            }

        }

    }
}
