using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ifScanObject : MonoBehaviour
{
    public int ifIndex = 0;
    public int checkCount;
    public int scanNum;

    public ScannableScriptableObject scannedObject;

    public TextMeshProUGUI ifCount;
    public List<GameObject> ifStatements;



    // Start is called before the first frame update
    void Start()
    {
        checkCount = 0;
        CheckIndex();
    }

    // Update is called once per frame
    void Update()
    {
        ifCount.text = checkCount.ToString();

        if(checkCount > scanNum)
        {
            incIndex();
        }
    }

    public void incIndex()
    {
        ifIndex++;
        ifIndex = ifIndex % ifStatements.Count;

        checkCount = 0;

        CheckIndex();
    }

    public void CheckCompare()
    {
        bool statementResult = false;

        switch (ifIndex) {
            case 0:
                statementResult = compareColor("Red", scannedObject);
                break;
            case 1:
                statementResult = compareColor("Blue", scannedObject);
                break;
            case 2:
                statementResult = compareColorAndShape("Red", "Cube", scannedObject);
                break;
            case 3:
                statementResult = compareColorOrShape("Blue", "Sphere", scannedObject);
                break;
            case 4:
                statementResult = compareNotColor("Red", scannedObject);
                break;
        }

        if(statementResult == true)
        {
            checkCount++;
        }

        Debug.Log("IS STATEMENT TRUE: " + statementResult + " " + checkCount);

    }

    public void CheckIndex()
    {
        for (int i = 0; i < ifStatements.Count; i++)
        {
            if(i == ifIndex)
            {
                ifStatements[i].SetActive(true);
            }
            else
            {
                ifStatements[i].SetActive(false);
            }
        }
    }


    //redColor, color = "Red"
    //blueColor, color = "Blue"
    public bool compareColor(string color, ScannableScriptableObject objectToScan)
    {
        bool result = false;

        if (objectToScan.color.CompareTo(color) == 0)
        {
            result = true;
        }

        return result;
    }

    //redColor && cube, color = "Red" shape = "Cube"
    public bool compareColorAndShape(string color, string shape, ScannableScriptableObject objectToScan)
    {
        bool result = false;

        if (objectToScan.color.CompareTo(color) == 0 && objectToScan.shape.CompareTo(shape) == 0)
        {
            result = true;
        }

        return result;
    }

    //blueColor || spehre, color = "Blue" shape = "Sphere"
    public bool compareColorOrShape(string color, string shape, ScannableScriptableObject objectToScan)
    {
        bool result = false;

        if (objectToScan.color.CompareTo(color) == 0 || objectToScan.shape.CompareTo(shape) == 0)
        {
            result = true;
        }

        return result;
    }

    public bool compareNotColor(string color, ScannableScriptableObject objectToScan)
    {
        bool result = false;

        if (objectToScan.color.CompareTo(color) != 0)
        {
            result = true;
        }

        return result;
    }

    public bool compareNotShape(string shape, ScannableScriptableObject objectToScan)
    {
        bool result = false;

        if (objectToScan.shape.CompareTo(shape) != 0)
        {
            result = true;
        }

        return result;
    }

}
