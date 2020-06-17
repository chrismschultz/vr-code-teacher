using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class Panel : MonoBehaviour
{
    public string panelID;
    public VRTK_SnapDropZone[] childDropZones;

    //Could concatinate into a string
    public List<int> blockKey;
    public List<int> actualKey;

    public int panelKeyInt;

    public string keyString;

    // Start is called before the first frame update
    void Start()
    {
        //Go through children objects and get the reference to the snapZone
        childDropZones = GetComponentsInChildren<VRTK_SnapDropZone>();

        //Add a listener for each zone to check if an object was added
        foreach(VRTK_SnapDropZone zone in childDropZones)
        {
            zone.ObjectSnappedToDropZone+=new SnapDropZoneEventHandler(ObjectSnappedInto);
            zone.ObjectUnsnappedFromDropZone+= new SnapDropZoneEventHandler(ObjectSnappedOut);
        }
    }

    public void GetKey()
    {
        blockKey.Clear();
        //Go through all the children drop zones
        foreach(VRTK_SnapDropZone zone in childDropZones)
        {
            //Get the block script and add the ID to the idKey list
            GameObject zoneBlock = zone.GetCurrentSnappedObject();

            if(zoneBlock != null)
            {
                blockKey.Add(zone.GetCurrentSnappedObject().GetComponent<Block>().id);
            }
            else{
                blockKey.Add(0);
            }
            
        }

        CalcPanelKey();
    }

    private void ObjectSnappedInto(object sender, SnapDropZoneEventArgs e)
    {
        GetKey();
    }

    private void ObjectSnappedOut(object sender, SnapDropZoneEventArgs e)
    {
        GetKey();
    }

    public bool CheckKey()
    {
        if (blockKey.Count != actualKey.Count)
        {
            return false;
        }
            
        for (int i = 0; i < blockKey.Count; i++) {
            if (blockKey[i] != actualKey[i])
            {
                return false;
            }
        }

        return true;
    }

    //String might work best since we can specifically check the order things were entered
    void CalcPanelKey()
    {
        panelKeyInt = 0;
        keyString = "";
        foreach(int key in blockKey)
        {
            panelKeyInt+= key;
            keyString+=key.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
