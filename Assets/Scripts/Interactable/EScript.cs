using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EScript : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private TextMeshProUGUI eText;
    Image image;
    RectTransform rectTransform;

    DialogueManager dialogueManager;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    void Start()
    {
        dialogueManager = DialogueManager.instance;
    }

    void Update()
    {
        var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint;
        
        var viewportPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
        var distanceFromCenter = Vector2.Distance(viewportPoint, Vector2.one * 0.5f);

        var show = distanceFromCenter < 0.2f;
        
        if(dialogueManager.dialogueInProgress)
            show = false;

        image.enabled = show;
        eText.enabled = show;
    }
}
