
using UnityEngine;

public class GamePausedState : GameBaseState
{
    public override void EnterState(GameStateManager player)
    {
        Time.timeScale = 0;
    }

    public override void UpdateState(GameStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState(GameStateManager player)
    {
        
    }
}
