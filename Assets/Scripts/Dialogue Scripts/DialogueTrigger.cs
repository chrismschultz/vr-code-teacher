using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public DialogueManager manager;

    public string dialogueID;

    public  DialogueManagerSpawner managerSpawn;

    private void Start()
    {
        
    }

    public void TriggerDialogue()
    {
        //manger = GameObject.Find("Dialgo")
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        //manager

        if (dialogueID.CompareTo("1.1") == 0)
        {
            managerSpawn.StartDialogue(dialogue);
        }
        else if (dialogueID.CompareTo("1.2") == 0)
        {
            managerSpawn.StartDialogue(dialogue);

        }
    }
}
