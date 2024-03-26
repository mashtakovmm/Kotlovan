using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: interactable interface
public class DialogueHaver : MonoBehaviour
{
    [Header("Broadcasting to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;

    [Header("Objects")]
    [SerializeField] private DialogueSO _dialogue;

    private Color defaultColor;
    private Color highlightColor = Color.cyan;
    private Renderer r;

    private void Start()
    {
        r = GetComponent<Renderer>();
        defaultColor = r.material.GetColor("_Color");
    }
    public void HandleDialogueRequest()
    {
        dialogueStartChannel.OnDialogueSOEventRequested(_dialogue);
    }

    public void Hightlight()
    {
        r.material.SetColor("_Color", highlightColor);
    }

    public void StopHighlight()
    {  
        r.material.SetColor("_Color", defaultColor);
    }
}
