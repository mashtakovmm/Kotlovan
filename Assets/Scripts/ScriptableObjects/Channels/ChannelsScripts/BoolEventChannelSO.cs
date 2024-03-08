using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/Bool Event Channel")]
public class BoolEventChannelSO : ScriptableObject
{
    public UnityAction<bool> OnBoolEventRequested;

    public void RaiseEvent(bool value) {
        OnBoolEventRequested?.Invoke(value);
    }
}
