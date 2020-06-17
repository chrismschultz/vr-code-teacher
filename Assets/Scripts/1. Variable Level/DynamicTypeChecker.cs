using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;

public class DynamicTypeChecker : MonoBehaviour
{
    Color startingColor;
    VRTK_SnapDropZone dropZone;
    Renderer backgroundRenderer;
    TextMeshPro textBox;

    //public int typeID;
    public typeInfo[] typeInfos;
    public int typeIndex;



    // Start is called before the first frame update
    void Start()
    {
        backgroundRenderer = transform.GetChild(2).GetComponent<Renderer>();
        startingColor = backgroundRenderer.material.color;

        textBox = GetComponentInChildren<TextMeshPro>();

        dropZone = GetComponentInChildren<VRTK_SnapDropZone>();
        dropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedInto);

        typeIndex = 0;
        textBox.text = typeInfos[typeIndex].text;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ObjectSnappedInto(object sender, SnapDropZoneEventArgs e)
    {
        TextBlock block = dropZone.GetCurrentSnappedObject().GetComponent<TextBlock>();

        /*
        if (block != null && block.id == typeID)
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
        }*/

        if(block!=null && block.id == typeInfos[typeIndex].id)
        {
            Debug.Log("Correct");
            backgroundRenderer.material.color = Color.green;
            typeIndex++;

            //Check index
            if (typeIndex > typeInfos.Length - 1)
            {
                typeIndex = 0;
            }
            

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

        textBox.text = typeInfos[typeIndex].text;

        Destroy(dropZone.GetCurrentSnappedObject().gameObject);
    }




    [System.Serializable]
    public class typeInfo
    {
        public string text;
        public int id;
    }
}
