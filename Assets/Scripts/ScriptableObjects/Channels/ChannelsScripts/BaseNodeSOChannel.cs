using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/BaseNode Event Channel")]
public class BaseNodeSOChannel : ScriptableObject
{
    public UnityAction<BaseNodeSO> OnBaseNodeSOEventRequested;

    public void RaiseEvent(BaseNodeSO value)
    {
        OnBaseNodeSOEventRequested?.Invoke(value);
    }
}
