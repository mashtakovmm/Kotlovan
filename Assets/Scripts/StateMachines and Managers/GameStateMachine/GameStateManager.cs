using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [Header("Listening to:")]
    [SerializeField] VoidEventChannelSO pauseChannel;
    [Header("Broadcasting to:")]
    [SerializeField] BoolEventChannelSO togglePauseMenuChanel;
    // States
    private GameBaseState currentState;
    public GamePausedState PausedState = new GamePausedState();
    public GamePlayedState PlayedState = new GamePlayedState();
    // Var
    private bool isPaused;

    private void Start()
    {
        currentState = PlayedState;
        currentState.EnterState(this);
    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        pauseChannel.OnVoidEventRequested += HandlePause;
    }

    private void OnDisable()
    {
        pauseChannel.OnVoidEventRequested -= HandlePause;
    }

    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    private void HandlePause()
    {
        Debug.Log("PAUSED\\UNPAUSED");
        if (isPaused)
        {
            SwitchState(PlayedState);
        }
        if (!isPaused)
        {
            SwitchState(PausedState);
        }
        isPaused = !isPaused;
        togglePauseMenuChanel.OnBoolEventRequested(isPaused);
    }
}
