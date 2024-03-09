using UnityEngine;

public class DialogueManager : MonoBehaviour, IDialogueNodeVisitor
{
    [Header("Listening to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;
    [Header("Broadcasting to:")]
    [SerializeField] private VoidEventChannelSO dialogueEndChannel;
    // [SerializeField] private SimpleNodeSOEventChannelSO simpleNodeDataChannel;
    // [SerializeField] private ChoiceNodeSOEventChannelSO choiceNodeDataChannel;
    [SerializeField] SimpleNodeDataChannelSO simpleNodeDataChannel;
    private DialogueSO currentDialogue;
    private BaseNodeSO currentNode;
    private BaseNodeSO nextNode;


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
        currentNode.Accept(this);
    }

    private void NextNode(BaseNodeSO node)
    {

    }

    private void EndDialogue()
    {
        dialogueEndChannel.OnVoidEventRequested();
    }

    private void HandleClick()
    {
        currentNode.Accept(this);
    }

    public void Visit(SimpleNodeSO node)
    {
        simpleNodeDataChannel.OnSimpleNodeDataRequested(node.Line, node.Speaker);
    }
    public void Visit(ChocesNodeSO node)
    {

        // Debug.Log(node.Options[0].NextNode.Line.Text); // test
    }
}
