using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CreateCustomBlock : CreatePrefab
{
    //Let the section manager know how many values to check for and how many we have correct
    public SectionManager sectionManager;

    //These hold all the potential elements to spawn
    public blockInfo[] blockInfos;
    private int textIndex;

    //Time between spawning blocks
    public float spawnTime = 2.5f;

    //Amount wrong/right
    public int correctValue;
    public int wrongValue;
    

    // Start is called before the first frame update
    void Start()
    {
        sectionManager.correctAmount = correctValue;
        sectionManager.totalCorrect = blockInfos.Length;
    }

    private void Update()
    {
        sectionManager.correctAmount = correctValue;
        sectionManager.totalCorrect = blockInfos.Length;
    }

    public void Spawn()
    {
        StartCoroutine("StartSpawning");
    }

    IEnumerator StartSpawning()
    {
        while (true)
        {
            spawnCustomBlock();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void spawnCustomBlock()
    {
        //Check to see if prefab has a textBlock
        if (prefab.GetComponent<TextBlock>() == null)
        {
            return;
        }
        else
        {
            //Set the text of the textBlock to what is in the array
            prefab.GetComponent<TextBlock>().text = blockInfos[textIndex].text;
            prefab.GetComponent<TextBlock>().id = blockInfos[textIndex].id;
            prefab.GetComponent<VRTK_InteractableObject>().holdButtonToGrab = true;

            textIndex++;

            //Check index
            if (textIndex > blockInfos.Length - 1)
            {
                textIndex = 0;
            }
            createPrefab();
        }
    }

    //These hold the information for the blocks that get spawned
    [System.Serializable]
    public class blockInfo
    {
        public string text;
        public int id;
    }

}
