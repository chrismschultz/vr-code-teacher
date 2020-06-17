using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class DropZoneManagerHandler : MonoBehaviour
{
    public bool updateText;

    public blockInfo[] blockinfos;

    public List<Transform> dropZoneMangers;
    public List<VRTK_SnapDropZone> snapZones;
    public List<TextBlock> textBlocks;

    // Start is called before the first frame update
    void Start()
    {
        if(updateText)
        {
            foreach (Transform child in transform)
            {
                dropZoneMangers.Add(child);
                snapZones.Add(child.GetChild(0).GetComponent<VRTK_SnapDropZone>());
                textBlocks.Add(child.GetChild(1).GetComponent<TextBlock>());
            }

            foreach(VRTK_SnapDropZone zones in snapZones)
            {
                //zones.ObjectUnsnappedFromDropZone += Zones_ObjectExitedSnapDropZone;
                
            }

        }

        

    }

    private void Zones_ObjectExitedSnapDropZone(object sender, SnapDropZoneEventArgs e)
    {
        //Debug.Log(e.snappedObject.ge);
        Debug.Log(sender.ToString());
        int blockIndex = int.Parse(sender.ToString());

        //Debug.Log("Value of snapped block" + snapZones[blockIndex].defaultSnappedInteractableObject.transform.GetComponent<TextBlock>().text);

        //int blockIndex = int.Parse(sender.ToString());
        //textBlocks[blockIndex].text = blockinfos[blockIndex].text;
        //textBlocks[blockIndex].id = blockinfos[blockIndex].id;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class blockInfo
    {
        public string text;
        public int id;
    }


}
