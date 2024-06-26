using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/DialogueSO Event Channel")]
public class DialogueSOEventChannelSO : ScriptableObject
{
    public UnityAction<DialogueSO> OnDialogueSOEventRequested;

    public void RaiseEvent(DialogueSO dialogue) {
        Debug.Log("event raised");
        OnDialogueSOEventRequested?.Invoke(dialogue);
    }
}
