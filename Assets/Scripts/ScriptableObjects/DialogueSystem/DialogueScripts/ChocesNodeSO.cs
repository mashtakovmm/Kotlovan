using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Nodes/ChocesNode")]
public class ChocesNodeSO : BaseNodeSO
{
    [SerializeField] private OptionsSO[] _options;

    public OptionsSO[] Options => _options;
}
