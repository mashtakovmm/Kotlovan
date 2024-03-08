using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnVoidEventRequested;

    public void RaiseEvent()
    {
        OnVoidEventRequested?.Invoke();
    }
}
