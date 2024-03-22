
using UnityEngine;

public class PlayerInDialogueState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void ExitState(PlayerStateManager player)
    {

    }
}
