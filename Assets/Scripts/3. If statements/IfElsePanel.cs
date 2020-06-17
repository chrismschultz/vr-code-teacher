using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IfElsePanel : MonoBehaviour
{

    public int conditionIndex;

    public List<ifListener> listeners;
    public List<string> elseTexts;


    public TextMeshProUGUI ifTextBox;
    public TextMeshProUGUI ifTrueBox;

    public TextMeshProUGUI elseTextBox;

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

        string elseText = "print(" + elseTexts[conditionIndex] + ")";
        elseTextBox.text = elseText;

        //Return to see if the condition is true
        return listeners[conditionIndex].condition.checkCondition();
    }

    // Update is called once per frame
    void Update()
    {

        if (CheckCondition())
        {
            printTextBox.text = listeners[conditionIndex].condition.ifTrueStatement;
        }
        else
        {
            printTextBox.text = elseTexts[conditionIndex];
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckCondition();
        }
    }
}
