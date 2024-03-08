using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHaver : MonoBehaviour
{
    [Header("Broadcasting to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;

    [Header("Objects")]
    [SerializeField] private DialogueSO _dialogue;

    public void HandleDialogueRequest() {
        Debug.Log("Starting Dialogue from NPC");
        dialogueStartChannel.OnDialogueSOEventRequested(_dialogue);
    }
}
