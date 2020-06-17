using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class TypeChecker : MonoBehaviour
{
    Color startingColor;
    VRTK_SnapDropZone dropZone;
    public int typeID;

    Renderer backgroundRenderer;

    // Start is called before the first frame update
    void Start()
    {
        backgroundRenderer = transform.GetChild(2).GetComponent<Renderer>();
        startingColor = backgroundRenderer.material.color;
        dropZone = GetComponentInChildren<VRTK_SnapDropZone>();
        dropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedInto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ObjectSnappedInto(object sender, SnapDropZoneEventArgs e)
    {
        TextBlock block = dropZone.GetCurrentSnappedObject().GetComponent<TextBlock>();
        if(block != null && block.id == typeID)
        {
            Debug.Log("Correct");
            backgroundRenderer.material.color = Color.green;
            Invoke("ColorBack", 1f);
        }
        else
        {
            Debug.Log("How dare you make such a mistake");
            backgroundRenderer.material.color = Color.red;
            Invoke("ColorBack", 1f);
        }
    }

    void ColorBack()
    {
        backgroundRenderer.material.color = startingColor;
    }

}
