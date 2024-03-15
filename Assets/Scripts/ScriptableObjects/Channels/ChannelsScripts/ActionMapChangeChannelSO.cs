using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/PlayerState Callback Channel")]
public class ActionMapChangeChannelSO : ScriptableObject
{
    public UnityAction OnDialogueMap;
    public UnityAction OnPlayerMap;

    public void EnablePlayerMap()
    {
        OnPlayerMap?.Invoke();
    }

    public void EnableDialogue()
    {
        OnDialogueMap?.Invoke();
    }
}
