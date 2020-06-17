using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;

public class ComparisonManager : MonoBehaviour
{
    public float firstCompare;
    public float secondCompare;
    public int compareID;
    Color startingColor;

    public Renderer backgroundRenderer;

    public TextMeshProUGUI variable1;
    public TextMeshProUGUI variable2;

    public VRTK_SnapDropZone dropZone;

    public compareInfo[] typeInfos;

    int infoIndex; 

    [System.Serializable]
    public class compareInfo
    {
        public float var1;
        public float var2;
        public int id;
    }

    // Start is called before the first frame update
    void Start()
    {
        dropZone.ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedInto);
        startingColor = backgroundRenderer.material.color;

        infoIndex = 0;
        variable1.text = typeInfos[infoIndex].var1.ToString();
        variable2.text = typeInfos[infoIndex].var2.ToString();
    }


    private void ObjectSnappedInto(object sender, SnapDropZoneEventArgs e)
    {
        TextBlock block = dropZone.GetCurrentSnappedObject().GetComponent<TextBlock>();
        
        if (block != null && block.id == typeInfos[infoIndex].id)
        {
            Debug.Log("Correct");
            backgroundRenderer.material.color = Color.green;

            infoIndex++;

            //Check index
            if (infoIndex > typeInfos.Length - 1)
            {
                infoIndex = 0;
            }

            variable1.text = typeInfos[infoIndex].var1.ToString();
            variable2.text = typeInfos[infoIndex].var2.ToString();

            Invoke("ColorBack", 1f);
        }
        else
        {
            Debug.Log("How dare you make such a mistake");
            backgroundRenderer.material.color = Color.red;
            Invoke("ColorBack", 1f);
        }
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    void GenerateID()
    {
        if(firstCompare < secondCompare)
        {
            compareID = 0;
        }
        else if(firstCompare > secondCompare)
        {
            compareID = 1;
        }
        else if (firstCompare == secondCompare)
        {
            compareID = 2;
        }

    }


    void ColorBack()
    {
        backgroundRenderer.material.color = startingColor;

        Destroy(dropZone.GetCurrentSnappedObject().gameObject);
    }


}
