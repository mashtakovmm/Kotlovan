using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Nodes/SimpleNode")]
public class SimpleNodeSO : BaseNodeSO
{
    [SerializeField] private BaseNodeSO _nextNode = null;
    public BaseNodeSO NextNode => _nextNode;
}
