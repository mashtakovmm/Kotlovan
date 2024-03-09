using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Nodes/ChocesNode")]
public class ChocesNodeSO : BaseNodeSO
{
    [SerializeField] private OptionsSO[] _options;

    public OptionsSO[] Options => _options;

    public override void Accept(IDialogueNodeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
