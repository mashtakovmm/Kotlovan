using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Listening to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;

    private void OnEnable()
    {
        dialogueStartChannel.OnDialogueSOEventRequested += StartDialogue;
    }

    private void StartDialogue(DialogueSO dialogue)
    {
        // Debug.Log($"{dialogue.StartNode.Line.Text}");
    }
}
