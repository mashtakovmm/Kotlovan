
using UnityEngine;

public class GamePlayedState : GameBaseState
{
    public override void EnterState(GameStateManager player)
    {
        Time.timeScale = 1;
    }

    public override void UpdateState(GameStateManager player)
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState(GameStateManager player)
    {
        throw new System.NotImplementedException();
    }
}
