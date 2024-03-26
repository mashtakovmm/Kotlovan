using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Nodes/SimpleNode")]
public class SimpleNodeSO : BaseNodeSO
{
    [SerializeField] private BaseNodeSO _nextNode = null;
    public BaseNodeSO NextNode => _nextNode;

    public override void Accept(IDialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
