using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManagerSpawner : MonoBehaviour
{
    public TextMeshProUGUI nameGUI;
    public TextMeshProUGUI dialogueGUI;

    private Queue<string> sentences;

    public string eventName;

    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Set the title of the text
        nameGUI.text = dialogue.name;

        sentences.Clear();

        //Go through each sentence in dialogue and add it to queue
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        //End the dialogue if we have no more sentences to show
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Get the first sentence 
        string sentence = sentences.Dequeue();

        //Display the sentence we want to show
        //dialogueGUI.text = sentence;

        StopAllCoroutines();
        //If we want the text to show each letter individually 
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueGUI.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueGUI.text += letter;
            yield return null;
        }
    }



    void EndDialogue()
    {
        if(eventName.CompareTo("1.1") == 0)
        {
            spawner = GameObject.Find("CustomBlockSpawner(bucket)");

            Debug.Log(spawner.name);

            spawner.GetComponent<CreateCustomBlock>().Spawn();
        }
        else if (eventName.CompareTo("1.2") == 0)
        {
            spawner = GameObject.Find("CustomBlockSpawner(variableBucket)");

            Debug.Log(spawner.name);

            spawner.GetComponent<CreateCustomBlock>().Spawn();
        }
        else if (eventName.CompareTo("1.3") == 0)
        {
            spawner = GameObject.Find("CustomBlockSpawner(1.3.1)");
            spawner.GetComponent<OperatorSpawner1_3>().Spawn();

            GameObject spawner2 = GameObject.Find("CustomBlockSpawner(1.3.2)");
            spawner2.GetComponent<OperatorSpawner1_3>().Spawn();
        }
            Debug.Log("End of Convo");
    }
    
}
