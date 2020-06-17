using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OperationPanel : MonoBehaviour
{
    //These reference all the different text elements
    public TextMeshProUGUI Xvalue;
    public TextMeshProUGUI Yvalue;
    public TextMeshProUGUI Value;
    public TextMeshProUGUI Xbelt;
    public TextMeshProUGUI operatorBelt;


    public string operatorBeltVal;
    public int xVal;
    public int yVal;
    public int answerVal;
    public int total;

    public OperatorBucket variableBucket;
    public OperatorBucket operatorBucket;

    public OperatorHolder[] operators;
    public int operatorIndex;

    private bool checkCorrect;

    // Start is called before the first frame update
    void Start()
    {
        operatorIndex = 0;
        checkCorrect = false;
    }

    public void CheckOperator()
    {
        if(xVal != null && yVal != null )
        {
            Debug.Log("Operator Value: " + operatorBeltVal + " X Value: " + xVal);
            switch (operatorBeltVal)
            {
                case "+":
                    total = xVal + yVal;
                    break;
                case "-":
                    total = xVal - yVal;
                    break;
                case "*":
                    total = xVal * yVal;
                    break;
                case "/":
                    total = xVal / yVal;
                    break;
            }

            

            if (total == answerVal )
            {
                Debug.Log("Correct");
                Invoke("CorrectAnswer", 2f);
            }
            else
            {
                Debug.Log("Incorrect");
            }
        }
    }

    public void CorrectAnswer()
    {
        operatorIndex++;
        

        operatorBucket.operatorValue = "";
        variableBucket.operatorValue = "";
    }

    public void SetYandAnswer()
    {
        Yvalue.text = operators[operatorIndex].yVal.ToString();
        yVal = operators[operatorIndex].yVal;

        Value.text = operators[operatorIndex].answer.ToString();
        answerVal = operators[operatorIndex].answer;
    }

    public void SetInputValues()
    {
        Xbelt.text = variableBucket.operatorValue;
        Xvalue.text = variableBucket.operatorValue;

        if(variableBucket.operatorValue.CompareTo("") != 0)
        {
            xVal = int.Parse(variableBucket.operatorValue);
        }
        

        operatorBelt.text = operatorBucket.operatorValue;
        operatorBeltVal = operatorBucket.operatorValue;
    }

    // Update is called once per frame
    void Update()
    {
        SetYandAnswer();
        SetInputValues();

        //CheckOperator();
    }

    


    [System.Serializable]
    public class OperatorHolder
    {
        public int yVal;
        public int answer;
    }


}
