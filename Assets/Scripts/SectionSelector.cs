using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSelector : MonoBehaviour
{
    //This class just holds all the sections for the level
    //Takes the section index and sets that section to active

    public List<GameObject> sections;

    public int sectionIndex;

    // Start is called before the first frame update
    void Start()
    {
        SetSection();
    }


    public void NextSection()
    {
        sectionIndex++;
        if(sectionIndex == sections.Count-1)
        {
            sectionIndex = sections.Count -1;
        }

        SetSection();
    }

    public void SetSection()
    {
        for (int i = 0; i < sections.Count; i++)
        {
            if(i == sectionIndex)
            {
                sections[i].SetActive(true);
            }
            else
            {
                sections[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
