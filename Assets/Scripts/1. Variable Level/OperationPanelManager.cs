using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VRTK;

public class OperationPanelManager : MonoBehaviour
{
    public List<TextMeshProUGUI> textHolder;

    public float var1;
    public float var2;

    public VRTK_SnapDropZone xVariableZone;
    public VRTK_SnapDropZone yVariableZone;

    public float addOperand;
    public float subtractOperand;
    public float multiplyOperand;
    public float divideOperand;
    public float moduloOperand;

    // Start is called before the first frame update
    void Start()
    {
        textHolder = new List<TextMeshProUGUI>();
        foreach(Transform child in transform)
        {
            if(child.GetComponent<TextMeshProUGUI>() != null)
            {
                textHolder.Add(child.GetComponent<TextMeshProUGUI>());
            }
            
        }


        xVariableZone.ObjectSnappedToDropZone += XVariableZone_ObjectSnappedToDropZone;
        yVariableZone.ObjectSnappedToDropZone += YVariableZone_ObjectSnappedToDropZone;

        xVariableZone.ObjectUnsnappedFromDropZone += XVariableZone_ObjectUnsnappedFromDropZone;
        yVariableZone.ObjectUnsnappedFromDropZone += YVariableZone_ObjectUnsnappedFromDropZone;

        UpdateText();
    }

    private void YVariableZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        var2 = 0;
        UpdateText();
    }

    private void XVariableZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
    {
        var1 = 0;
        UpdateText();
    }

    private void XVariableZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        TextBlock xBlock = xVariableZone.GetCurrentSnappedObject().GetComponent<TextBlock>();
        var1 = float.Parse(xBlock.text);
        UpdateText();
    }

    private void YVariableZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
    {
        TextBlock yBlock = yVariableZone.GetCurrentSnappedObject().GetComponent<TextBlock>();
        var2 = float.Parse(yBlock.text);
        UpdateText();
    }


    public void UpdateText()
    {
        addOperand = var1 + var2;
        textHolder[0].text = var1.ToString() + " + " + var2.ToString() + " = " + addOperand;

        subtractOperand = var1 - var2;
        textHolder[1].text = var1.ToString() + " - " + var2.ToString() + " = " + subtractOperand;

        multiplyOperand = var1 * var2;
        textHolder[2].text = var1.ToString() + " * " + var2.ToString() + " = " + multiplyOperand;

        if(var2 != 0)
        {
            divideOperand = var1 / var2;
            textHolder[3].text = var1.ToString() + " / " + var2.ToString() + " = " + divideOperand;
        }
        else
        {
            textHolder[3].text = var1.ToString() + " / 0"  + " = ERROR";
        }
        

        moduloOperand = var1 % var2;
        textHolder[4].text = var1.ToString() + " % " + var2.ToString() + " = " + moduloOperand;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
