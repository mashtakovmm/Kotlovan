using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/ChoiceNodeData Event Channel")]
public class ChoiceNodeDataChannelSO : ScriptableObject
{
    public UnityAction<DialogueLineSO, DialogueSpeakerSO, OptionsSO[]> OnChoiceNodeDataRequested;

    public void RaiseEvent(DialogueLineSO line, DialogueSpeakerSO speaker, OptionsSO[] options) {
        OnChoiceNodeDataRequested?.Invoke(line, speaker, options);
    }
}
