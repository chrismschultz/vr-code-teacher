using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OperatorBucket : MonoBehaviour
{
    public OperationPanel operationPanel;
    public string operatorValue;

    public bool isOperator; 


    // Start is called before the first frame update
    void Start()
    {
        operatorValue = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        TextBlock block = other.gameObject.GetComponent<TextBlock>();
        if (block != null && block.gameObject.tag == "Block")
        {

            operatorValue = block.text;



            Destroy(other.gameObject);
        }
        else
        {

            if (other.tag == "Block")
            {
                Destroy(other.gameObject);
            }

        }
        Debug.Log("CHECKING OPERATOR");
        operationPanel.SetInputValues();
        operationPanel.CheckOperator();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
