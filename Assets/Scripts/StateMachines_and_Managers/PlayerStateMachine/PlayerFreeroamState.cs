
using UnityEngine;

public class PlayerFreeroamState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Enter freeroam state");
    }

    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void ExitState(PlayerStateManager player)
    {

    }
}
