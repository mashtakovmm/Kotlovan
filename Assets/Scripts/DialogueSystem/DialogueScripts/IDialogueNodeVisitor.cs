using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogueNodeVisitor
{
    void Visit(SimpleNodeSO node);
    void Visit(ChocesNodeSO node);
}
