using UnityEngine;

public class GamePlayedState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Time.timeScale = 1;
    }
    public override void UpdateState(GameStateManager game)
    {

    }
}
