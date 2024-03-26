using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event Channels/Change ActionMap Event Channel")]
public class ChangeActionMapSOChannel : ScriptableObject
{
    public UnityAction OnEnablePlayer;
    public UnityAction OnEnableDialogue;
    public UnityAction OnEnableUI;

    public void EnablePlayer()
    {
        OnEnablePlayer?.Invoke();
    }

    public void EnableDiaglogue()
    {
        OnEnableDialogue?.Invoke();
    }

    public void EnalbleUI()
    {
        OnEnableUI?.Invoke();
    }
}
