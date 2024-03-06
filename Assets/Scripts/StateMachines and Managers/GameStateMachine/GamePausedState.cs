using UnityEngine;

public class GamePausedState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Time.timeScale = 0;
    }
    public override void UpdateState(GameStateManager game)
    {

    }
}
