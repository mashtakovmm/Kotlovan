
using UnityEngine;

public class PlayerFreeroamState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void ExitState(PlayerStateManager player)
    {

    }
}
