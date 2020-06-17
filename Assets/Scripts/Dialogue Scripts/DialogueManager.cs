using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameGUI;
    public TextMeshProUGUI dialogueGUI;

    private Queue<string> sentences;


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
            Debug.Log("End of Convo");
    }
    
}
