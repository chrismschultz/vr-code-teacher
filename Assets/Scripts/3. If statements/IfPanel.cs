using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IfPanel : MonoBehaviour
{

    public int conditionIndex;
    
    public List<ifListener> listeners;


    public TextMeshProUGUI ifTextBox;
    public TextMeshProUGUI ifTrueBox;

    public TextMeshProUGUI printTextBox;

    // Start is called before the first frame update
    void Start()
    {
        conditionIndex = 0;


        CheckCondition();



    }

    public bool CheckCondition()
    {
        //Get conditional statement from the current ifListener
        ifTextBox.text = listeners[conditionIndex].condition.GetConditionStatement();

        //Want to format the print statement using the listeners ifTrueStatement
        string ifTrueText = "print(" + listeners[conditionIndex].condition.ifTrueStatement + ")";
        ifTrueBox.text = ifTrueText;
        
        //Return to see if the condition is true
        return listeners[conditionIndex].condition.checkCondition();
    }

    // Update is called once per frame
    void Update()
    {

        if(CheckCondition())
        {
            printTextBox.text = listeners[conditionIndex].condition.ifTrueStatement;
        }
        else
        {
            printTextBox.text = "";
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckCondition();
        }
    }
}
