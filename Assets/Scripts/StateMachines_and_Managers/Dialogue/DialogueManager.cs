using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour, IDialogueNodeVisitor
{
    [Header("Listening to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;
    [SerializeField] BaseNodeSOChannel nextNodeCallbackChannel;
    [Header("Broadcasting to:")]
    [SerializeField] private VoidEventChannelSO dialogueEndChannel;
    // [SerializeField] private SimpleNodeSOEventChannelSO simpleNodeDataChannel;
    // [SerializeField] private ChoiceNodeSOEventChannelSO choiceNodeDataChannel;
    [SerializeField] SimpleNodeDataChannelSO simpleNodeDataChannel;
    [SerializeField] ChoiceNodeDataChannelSO choiceNodeDataChannel;
    private DialogueSO currentDialogue;
    private BaseNodeSO currentNode;
    private BaseNodeSO nextNode;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        playerInputActions.Dialogue.MouseClick.performed += HandleClick;
        dialogueStartChannel.OnDialogueSOEventRequested += StartDialogue;
        nextNodeCallbackChannel.OnBaseNodeSOEventRequested += HandleNextNodeCallback;
    }

    private void OnDisable()
    {
        playerInputActions.Dialogue.MouseClick.Disable();
        playerInputActions.Dialogue.MouseClick.performed -= HandleClick;
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

    private void HandleClick(InputAction.CallbackContext context)
    {
        NextNode(nextNode);
    }

    private void HandleNextNodeCallback(BaseNodeSO node)
    {
        nextNode = node;
        NextNode(nextNode);
    }

    public void Visit(SimpleNodeSO node)
    {
        simpleNodeDataChannel.OnSimpleNodeDataRequested(node.Line, node.Speaker);
        Debug.Log("Data sent");
        playerInputActions.Dialogue.MouseClick.Enable();
        nextNode = node.NextNode;
    }
    public void Visit(ChocesNodeSO node)
    {
        playerInputActions.Dialogue.MouseClick.Disable();
        choiceNodeDataChannel.OnChoiceNodeDataRequested(node.Line, node.Speaker, node.Options);
    }
}
