using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    DialogueManager dialogueManager;
    public DialogueScriptableObject dialogueFile;

    void Start()
    {
        dialogueManager = DialogueManager.instance;
    }
    
    public void Interact()
    {
        if(dialogueManager.canStartDialogue)
            dialogueManager.TriggerDialogue(dialogueFile);
    }
}
