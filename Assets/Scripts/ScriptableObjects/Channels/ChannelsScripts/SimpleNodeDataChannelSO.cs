using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/SimpleNodeData Event Channel")]
public class SimpleNodeDataChannelSO : ScriptableObject
{
    public UnityAction<DialogueLineSO, DialogueSpeakerSO> OnSimpleNodeDataRequested;

    public void RaiseEvent(DialogueLineSO line, DialogueSpeakerSO speaker) {
        OnSimpleNodeDataRequested?.Invoke(line, speaker);
    }
}
