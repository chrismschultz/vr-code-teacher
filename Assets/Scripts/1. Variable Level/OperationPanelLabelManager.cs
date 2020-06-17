using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OperationPanelLabelManager : MonoBehaviour
{
    OperationPanelManager manager;

    public List<TextMeshProUGUI> textHolder;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<OperationPanelManager>();

        textHolder = new List<TextMeshProUGUI>();
        foreach (Transform child in transform)
        {
            if (child.GetComponent<TextMeshProUGUI>() != null)
            {
                textHolder.Add(child.GetComponent<TextMeshProUGUI>());
            }

        }
    }

    void UpdateText()
    {
        float addOperand = manager.addOperand;
        textHolder[0].text = "X + Y  = " + addOperand;

        float subtractOperand = manager.subtractOperand;
        textHolder[1].text = "X - Y = " + subtractOperand;

        float multiplyOperand = manager.multiplyOperand;
        textHolder[2].text = "X * Y = " + multiplyOperand;

        if (manager.var2 != 0)
        {
            float divideOperand = manager.divideOperand;
            textHolder[3].text = "X / Y = " + divideOperand;
        }
        else
        {
            textHolder[3].text = "X / 0" + " = ERROR";
        }


        float moduloOperand = manager.moduloOperand;
        textHolder[4].text = "X % Y = " + moduloOperand;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
}
