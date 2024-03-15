
using UnityEngine;

public class PlayerInDialogueState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player, ActionMapChangeChannelSO actionMapChangeChannel)
    {
        Debug.Log($"Enter dialogue state, set map channel: {actionMapChangeChannel}");
        actionMapChangeChannel.OnDialogueMap();
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void ExitState(PlayerStateManager player)
    {

    }
}
