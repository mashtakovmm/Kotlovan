using UnityEngine;

[CreateAssetMenu(menuName ="DialogueSystem/Nodes/Options")]
public class OptionsSO : ScriptableObject
{
    [SerializeField] private BaseNodeSO _nextNode = null;
    [SerializeField] private string _optionText;
    
    public BaseNodeSO NextNode => _nextNode;
    public string OptionText => _optionText;
}
