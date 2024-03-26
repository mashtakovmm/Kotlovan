using UnityEngine;
using UnityEngine.Events;

// [CreateAssetMenu(menuName = "Event Channels/ChoiceNode Event Channel")]
public class ChoiceNodeSOEventChannelSO : ScriptableObject
{
    public UnityAction<ChocesNodeSO> OnChocesNodeSOEventRequested;

    public void RaiseEvent(ChocesNodeSO value)
    {
        OnChocesNodeSOEventRequested?.Invoke(value);
    }
}
