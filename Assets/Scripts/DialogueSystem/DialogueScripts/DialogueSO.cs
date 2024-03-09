using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Dialogue")]
public class DialogueSO : ScriptableObject
{
    [SerializeField] private BaseNodeSO _startNode;

    public BaseNodeSO StartNode => _startNode;
}
