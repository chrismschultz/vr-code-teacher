using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    //This is the manager for each section, it keeps track of how many right answers the user needs before it swaps sections

    //This will change sections
    public SectionSelector sectionSelector;

    //This is how many total correct answers we want
    public int totalCorrect;

    //This is the correct amount of answers the user has
    public int correctAmount;

    public bool sectionComplete;

    // Start is called before the first frame update
    void Start()
    {
        sectionComplete = false;
    }

    public void SectionOver()
    {
        sectionSelector.NextSection();
    }

    // Update is called once per frame
    void Update()
    {
        //If the user got the right amount of correct answers go to the next section
        //Could call this in an Invoke() method so it doesnt swap immediately 
        if(correctAmount == totalCorrect && sectionComplete == false)
        {
            Debug.Log("SECTION OVER");
            SectionOver();
            sectionComplete = true;

        }
    }
}
