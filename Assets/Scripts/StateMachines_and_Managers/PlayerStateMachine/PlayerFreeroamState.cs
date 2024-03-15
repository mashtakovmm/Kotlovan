
using UnityEngine;

public class PlayerFreeroamState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player, ActionMapChangeChannelSO actionMapChangeChannel)
    {
        Debug.Log($"Enter freeroam state, set map channel: {actionMapChangeChannel}");
        actionMapChangeChannel.OnPlayerMap();
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void ExitState(PlayerStateManager player)
    {

    }
}
