using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Channels
    [SerializeField] VoidEventChannelSO pauseChannel;
    // States
    private GameBaseState currentState;
    public GamePausedState PausedState = new GamePausedState();
    public GamePlayedState PlayedState = new GamePlayedState();
    // Var
    private bool isPaused = false;

    private void Start()
    {
        currentState = PlayedState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        Debug.Log(currentState);
    }

    private void OnEnable() {
        pauseChannel.OnVoidEventRequested += HandlePause;
    }

    private void OnDisable() {
        pauseChannel.OnVoidEventRequested -= HandlePause;
    }

    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void HandlePause()
    {
        isPaused = !isPaused;
        
        if (isPaused)
        {
            SwitchState(PlayedState);
        }
        if (!isPaused)
        {
            SwitchState(PausedState);
        }
    }
}
