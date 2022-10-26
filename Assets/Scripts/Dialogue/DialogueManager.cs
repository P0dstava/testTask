using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    void Awake()
    {
        if(instance != null)
            Debug.LogWarning("Instance freak up");
        instance = this;
    }

    //Manager variables
    public TextMeshProUGUI nameText, dialogueText;
    public Canvas dialBox;
    //public Collider2D player;
    public GameObject nameBox;
    
    public DialogueScriptableObject dialogueFile;
   
    public bool dialogueInProgress = false, sentenceFinished = true, canStartDialogue = true;
    
    private Queue<string> sentences;
    public Queue<Dialogue> Dialogues;

    private Dialogue dialogue;

    void Start()
    {
        sentences = new Queue<string>();
        Dialogues = new Queue<Dialogue>();
        dialBox.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {   
        if(dialogueInProgress && sentenceFinished)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                DisplayNextSentence();
            }
        }
    }

    public void TriggerDialogue(DialogueScriptableObject dialogueFile)
    {
        for(int i=0; i < dialogueFile.dialogues.Length; i++)
        {
            Dialogues.Enqueue(dialogueFile.dialogues[i]);
        }
        if(canStartDialogue)
            StartDialogue();
    }

    //Starting dialogue
    public void StartDialogue()
    {   
        canStartDialogue = false;
        dialogueInProgress = true;
        dialogue = Dialogues.Dequeue();
        ContinueDialogue(dialogue);
        dialBox.GetComponent<Canvas>().enabled = true;
    }

    //Check if we have more sentences and if dialogue contains Name than we display nameBox
    public void ContinueDialogue(Dialogue dialogue)
    {   
        sentences.Clear();

        nameText.text = dialogue.name;
        if(dialogue.name == "")
            nameBox.SetActive(false);
        else
            nameBox.SetActive(true);
        
        foreach(string sentence in dialogue.sentences)
        {   
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //Dequeueing sentences
    public void DisplayNextSentence()
    {   
        if (sentences.Count == 0)
        {
            DisplayNextDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Function to type sentence letter by letter
    IEnumerator TypeSentence(string sentence)
    {   
        sentenceFinished = false;
        dialogueText.text = "";
        char[] letters = sentence.ToCharArray();
        int i = 0;
        
        while(i <= letters.Length && !sentenceFinished)
        {  
            if(Input.GetKey(KeyCode.R)) //Skipping sentence
            {
                if(dialogueText.text != sentence)
                {
                    sentenceFinished = true;
                    dialogueText.text = sentence;
                    i = letters.Length;
                    yield return new WaitForSeconds(0.1f);
                }
            }         
            if(dialogueText.text != sentence) //Typing sentence
            {
                dialogueText.text += letters[i];
                i++;
                yield return new WaitForSeconds(0.01f);
            }
            if(dialogueText.text.ToString() == sentence)
            {
                    sentenceFinished = true;
                    i = letters.Length;
                    yield break;
            }
        }
    }

    //Sending next Dialogue to display
    void DisplayNextDialogue()
    {   
        if (Dialogues.Count == 0 && sentences.Count == 0)
        {
            EndDialogues();
            return;
        }
        StartDialogue();
    }

    void EndDialogues()
    {   
        Dialogues.Clear();
        dialBox.GetComponent<Canvas>().enabled = false;
        dialogueInProgress = false;
        Invoke("TurnOnCanStartDialogue",1f);
    }

    void TurnOnCanStartDialogue()
    {
        canStartDialogue = true;
    }
}
