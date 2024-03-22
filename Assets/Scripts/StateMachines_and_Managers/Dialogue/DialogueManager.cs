using UnityEngine;

public class DialogueManager : MonoBehaviour, IDialogueNodeVisitor
{
    [SerializeField] InputReader inputReader;
    [Header("Listening to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;
    [SerializeField] BaseNodeSOChannel nextNodeCallbackChannel;
    [Header("Broadcasting to:")]
    [SerializeField] private VoidEventChannelSO dialogueEndChannel;
    [SerializeField] SimpleNodeDataChannelSO simpleNodeDataChannel;
    [SerializeField] ChoiceNodeDataChannelSO choiceNodeDataChannel;
    private DialogueSO currentDialogue;
    private BaseNodeSO currentNode;
    private BaseNodeSO nextNode;
    private bool isPrevNodeChoice;

    private void OnEnable()
    {
        inputReader.MouseClickEvent += HandleClick;
        dialogueStartChannel.OnDialogueSOEventRequested += StartDialogue;
        nextNodeCallbackChannel.OnBaseNodeSOEventRequested += HandleNextNodeCallback;
    }

    private void OnDisable()
    {
        inputReader.MouseClickEvent -= HandleClick;
        dialogueStartChannel.OnDialogueSOEventRequested -= StartDialogue;
        nextNodeCallbackChannel.OnBaseNodeSOEventRequested -= HandleNextNodeCallback;
    }

    private void StartDialogue(DialogueSO dialogue)
    {
        currentDialogue = dialogue;
        currentNode = dialogue.StartNode;
        currentNode.Accept(this);
    }

    private void NextNode(BaseNodeSO node)
    {
        if (node)
        {
            node.Accept(this);
        }
        else
        {
            EndDialogue();
        }

    }

    private void EndDialogue()
    {
        Debug.Log("dialogue ended");
        dialogueEndChannel.OnVoidEventRequested();
    }

    private void HandleClick()
    {
        if (!isPrevNodeChoice) { NextNode(nextNode); }
    }

    private void HandleNextNodeCallback(BaseNodeSO node)
    {
        nextNode = node;
        NextNode(nextNode);
    }

    public void Visit(SimpleNodeSO node)
    {
        isPrevNodeChoice = false;
        simpleNodeDataChannel.OnSimpleNodeDataRequested(node.Line, node.Speaker);
        Debug.Log("Data sent");
        nextNode = node.NextNode;
    }
    public void Visit(ChocesNodeSO node)
    {
        isPrevNodeChoice = true;
        choiceNodeDataChannel.OnChoiceNodeDataRequested(node.Line, node.Speaker, node.Options);
    }
}
