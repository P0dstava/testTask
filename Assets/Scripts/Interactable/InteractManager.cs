using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public GameObject interactPoint;
    public float interactRange;
    public LayerMask interactable;
    public bool canInteract = true;
    Collider obj;

    DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = DialogueManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract)
        {
            obj = DetectInteractable();
            if(obj)
            {
                if(Vector2.Distance(interactPoint.transform.position, obj.GetComponent<Transform>().position) > interactRange)
                    obj = null;

                if(Input.GetKeyUp(KeyCode.E) && obj && !dialogueManager.dialogueInProgress)
                {
                    Interact(obj);
                }
            }
        }
    }

    //Detecting and returning closest object that is on "interactable" layer and has Collider
    Collider DetectInteractable()
    {
        Collider[] objToInteract = Physics.OverlapSphere(interactPoint.transform.position, interactRange, interactable);

        if(objToInteract.Length!=0)
            obj = objToInteract[0];
        return obj;
    }

    //Looking for "Interactable" script and calls Interact() method in obj when called
    void Interact(Collider obj)
    {
        obj.GetComponent<Interactable>().Interact();
    }
}
