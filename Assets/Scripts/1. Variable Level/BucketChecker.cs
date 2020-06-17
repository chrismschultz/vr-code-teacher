using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketChecker : MonoBehaviour
{
    //This is the code for each bucket

    //Store the starting color of the bucket so we can revert back to it
    Color startingColor;

    //This checks to see if the blocks passed in are the right ones
    public int BucketID;

    //This is located in the parent of all the buckets
    public GameObject blockSpawner;

    

    // Start is called before the first frame update
    void Start()
    {
        //Get starting color
        startingColor = gameObject.GetComponent<Renderer> ().material.color;
        //blockSpawner = GameObject.Find("CustomBlockSpawner(bucket)");
    }

    //When a block enters the bucket check the block informations
    private void OnTriggerEnter(Collider other)
    {
        //Get access to the textBlock script
        TextBlock block = other.gameObject.GetComponent<TextBlock>();

        //If the block has the script and the ID's match we got the correct answer
        if (block != null && block.id == BucketID && block.gameObject.tag == "Block")
        {
            Debug.Log("Correct");
            //Change the bucket color to green since its correct
            gameObject.GetComponent<Renderer> ().material.color = Color.green;

            //Increment the number of correct answers
            blockSpawner.GetComponent<CreateCustomBlock>().correctValue++;

            //Turn the color back to starting color
            Invoke("ColorBack", 1f);

            //Detroy the block to save memory
            Destroy(other.gameObject);
        }
        //If the block has the wrong ID
        else if (block != null && block.id != BucketID && block.gameObject.tag == "Block"){
            Debug.Log("How dare you make such a mistake");
            //Change color to red
            gameObject.GetComponent<Renderer> ().material.color = Color.red;
            //Increment wrong values
            blockSpawner.GetComponent<CreateCustomBlock>().wrongValue++;

            Invoke("ColorBack", 1f);
            if(other.tag == "Block")
            {
                Destroy(other.gameObject);
            }
            
        }
        
    }

    void ColorBack()
    {
        gameObject.GetComponent<Renderer> ().material.color = startingColor;
        //blockSpawner.GetComponent<CreateCustomBlock>().spawnCustomBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
