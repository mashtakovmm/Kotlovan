using UnityEngine;

public abstract class BaseNodeSO : ScriptableObject
{
    [SerializeField] private DialogueLineSO _line;
    [SerializeField] private DialogueSpeakerSO _speaker;

    public DialogueLineSO Line => _line;
    public DialogueSpeakerSO Speaker => _speaker;

    public abstract void Accept(IDialogueNodeVisitor visitor);


}
