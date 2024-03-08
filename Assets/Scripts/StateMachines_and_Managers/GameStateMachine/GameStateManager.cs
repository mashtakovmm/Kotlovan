using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    [Header("Channels")]
    [Header("Listening to:")]
    [SerializeField] private BoolEventChannelSO pauseChannel;
    private GameBaseState currentState;
    public GamePausedState PausedState = new GamePausedState();
    public GamePlayedState PlayedState = new GamePlayedState();


    void Start()
    {
        currentState = PlayedState;
        currentState.EnterState(this);
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        pauseChannel.OnBoolEventRequested += HandlePauseButton;
    }

    private void OnDisable()
    {
        pauseChannel.OnBoolEventRequested -= HandlePauseButton;
    }

    private void HandlePauseButton(bool isPaused)
    {
        if (!isPaused)
        {
            currentState = PlayedState;
            currentState.EnterState(this);
        }
        else
        {
            currentState = PausedState;
            currentState.EnterState(this);
        }
    }
}
