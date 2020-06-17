using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileLoopManager : MonoBehaviour
{
    public LoopSection testSection;
    public List<LoopSection> allSections;

    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform child in transform)
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
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Value of x = " + i);
            allSections[0].printAreaBody.text = allSections[0].printAreaBody.text + "Value of x = " + i + "\n";
            yield return new WaitForSeconds(1f);
        }
    }


    IEnumerator loopOne()
    {
        allSections[1].printAreaBody.text = "";
        for (int var = 17; var >= 12; var--)
        {
            Debug.Log("Value of i = " + var);
            allSections[1].printAreaBody.text = allSections[1].printAreaBody.text + "Value of i = " + var + "\n";
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator loopTwo()
    {
        allSections[2].printAreaBody.text = "";
        for (int j = 1; j <= 8; j = j + 1)
        {
            //If the remainder of j / 2 is 0
            if (j % 2 == 0)
            {
                allSections[2].printAreaBody.text = allSections[2].printAreaBody.text + j + " is even" + "\n";
            }
            else
            {
                allSections[2].printAreaBody.text = allSections[2].printAreaBody.text + j + " is odd" + "\n";
            }

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator loopThree()
    {
        allSections[3].printAreaBody.text = "";
        for (int i = 0; i <= 7; i++)
        {
            int squareValue = i * i;
            allSections[3].printAreaBody.text = allSections[3].printAreaBody.text + i + " squared = " + squareValue + "\n";
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator loopFour()
    {
        allSections[4].printAreaBody.text = "";
        for (int j = 0; j <= 50; j++)
        {
            allSections[4].printAreaBody.text = allSections[4].printAreaBody.text + "Value of j = " + 1 +  "\n";
            Debug.Log(allSections[4].printAreaBody.text.Length);
            if(allSections[4].printAreaBody.text.Length > 250)
            {
                break;
            }

            yield return new WaitForSeconds(1f);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
