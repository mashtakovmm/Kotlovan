using UnityEngine;

public class DialogueManager : MonoBehaviour, IDialogueNodeVisitor
{
    [Header("Listening to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;
    [Header("Broadcasting to:")]
    [SerializeField] private VoidEventChannelSO dialogueEndChannel;
    private DialogueSO currentDialogue;
    private BaseNodeSO currentNode;


    private void OnEnable()
    {
        dialogueStartChannel.OnDialogueSOEventRequested += StartDialogue;
    }

    private void OnDisable()
    {
        dialogueStartChannel.OnDialogueSOEventRequested -= StartDialogue;
    }

    private void StartDialogue(DialogueSO dialogue)
    {
        currentDialogue = dialogue;
        currentNode = dialogue.StartNode;
    }

    private void EndDialogue()
    {
        dialogueEndChannel.OnVoidEventRequested();
    }

    public void Visit(SimpleNodeSO node)
    {
        Debug.Log(node.NextNode.Line.Text); // test
    }
    public void Visit(ChocesNodeSO node)
    {
        Debug.Log(node.Options[0].NextNode.Line.Text); // test
    }
}
