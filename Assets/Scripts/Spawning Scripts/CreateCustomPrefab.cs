using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCustomPrefab : CreatePrefab
{
    public string[] textForBlocks;
    public blockInfo[] blockInfos;
    public int textIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void spawnCustomPrefab()
    {
        //Check to see if prefab has a textBlock
        if(prefab.GetComponent<TextBlock>() == null)
        {
            return;
        }
        else
        {
            //Set the text of the textBlock to what is in the array
           prefab.GetComponent<TextBlock>().text = textForBlocks[textIndex];
           textIndex++;

            //Check index
            if(textIndex > textForBlocks.Length-1)
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
