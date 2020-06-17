using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class OperatorSpawner1_3 : CreatePrefab
{
    public blockInfo[] blockInfos;
    private int textIndex;

    public float spawnTime = 2.5f;

    public int correctValue;
    public int wrongValue;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

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


    [System.Serializable]
    public class blockInfo
    {
        public string text;
        public int id;
    }
}
