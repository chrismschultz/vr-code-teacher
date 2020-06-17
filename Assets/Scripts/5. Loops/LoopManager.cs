using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    public LoopSection testSection;
    public List<LoopSection> allSections;

    // Start is called before the first frame update
    void Start()
    {
        testSection.printAreaBody.text = "";

        foreach(Transform child in transform)
        {
            allSections.Add(child.GetComponent<LoopSection>());
            child.GetComponent<LoopSection>().printAreaBody.text = "";
        }

    }


    public void StartLoop(int loopID)
    {
        switch (loopID)
        {
            case 0:
                StartCoroutine(loopZero());
                break;
            case 1:
                StartCoroutine(loopOne());
                break;
            case 2:
                StartCoroutine(loopTwo());
                break;
            case 3:
                StartCoroutine(loopThree());
                break;
            case 4:
                StartCoroutine(loopFour());
                break;
        }
    }


    IEnumerator loopZero()
    {
        allSections[0].printAreaBody.text = "";
        for (int i = 0; i < 5; i ++)
        {
            Debug.Log("Value of i = " + i);
            allSections[0].printAreaBody.text = allSections[0].printAreaBody.text + "Value of i = " + i + "\n";
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator loopOne()
    {
        allSections[1].printAreaBody.text = "";
        for (int f = 5; f <= 10; f++)
        {
            Debug.Log("Value of f = " + f);
            allSections[1].printAreaBody.text = allSections[1].printAreaBody.text + "Value of f = " + f + "\n";
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator loopTwo()
    {
        allSections[2].printAreaBody.text = "";
        for (int var = 17; var > 12; var--)
        {
            Debug.Log("Value of var = " + var);
            allSections[2].printAreaBody.text = allSections[2].printAreaBody.text + "Value of var = " + var + "\n";
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator loopThree()
    {
        allSections[3].printAreaBody.text = "";
        for (int j = 1; j <= 8; j = j + 1)
        {
            //If the remainder of j / 2 is 0
            if (j % 2 == 0)
            {
                allSections[3].printAreaBody.text = allSections[3].printAreaBody.text + j + " is even" + "\n";
            }
            else
            {
                allSections[3].printAreaBody.text = allSections[3].printAreaBody.text + j + " is odd" + "\n";
            }

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator loopFour()
    {
        allSections[4].printAreaBody.text = "";
        for (int i = 0; i <= 7; i++)
        {
            int squareValue = i * i; 
            allSections[4].printAreaBody.text = allSections[4].printAreaBody.text + i + " squared = " + squareValue + "\n";
            yield return new WaitForSeconds(1f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
