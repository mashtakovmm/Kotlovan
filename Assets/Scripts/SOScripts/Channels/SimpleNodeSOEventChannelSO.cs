using UnityEngine;
using UnityEngine.Events;

// [CreateAssetMenu(menuName = "Event Channels/SimpleNodeData Event Channel")]
public class SimpleNodeSOEventChannelSO : ScriptableObject
{
    public UnityAction<SimpleNodeSO> OnSimpleNodeEventRequested;

    public void RaiseEvent(SimpleNodeSO value)
    {
        OnSimpleNodeEventRequested?.Invoke(value);
    }
}
