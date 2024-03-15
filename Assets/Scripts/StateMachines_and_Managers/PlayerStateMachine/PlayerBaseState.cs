public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager player, ActionMapChangeChannelSO actionMapChangeChannel);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void ExitState(PlayerStateManager player);
}
