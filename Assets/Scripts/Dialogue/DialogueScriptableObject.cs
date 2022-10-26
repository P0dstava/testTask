using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues/Dialogue")]

public class DialogueScriptableObject : ScriptableObject
{
    public Dialogue[] dialogues;
}
