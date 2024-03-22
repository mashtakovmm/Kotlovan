using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private static PlayerStateManager _instance;
    public static PlayerStateManager Instance => _instance;
    private PlayerBaseState _currentState;
    public PlayerBaseState currentState => _currentState;
    public PlayerFreeroamState FreeroamState = new PlayerFreeroamState();
    public PlayerInDialogueState DialogueState = new PlayerInDialogueState();

    [Header("Listening to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;
    [SerializeField] private VoidEventChannelSO dialogueEndChannel;
    void Start()
    {
        if (_instance == null)
        {
            _currentState = FreeroamState;
            _currentState.EnterState(this);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {

    }

    private void OnEnable()
    {
        dialogueStartChannel.OnDialogueSOEventRequested += HandleDialogueStart;
        dialogueEndChannel.OnVoidEventRequested += HandleDialogueEnd;
    }

    private void OnDisable()
    {
        dialogueStartChannel.OnDialogueSOEventRequested -= HandleDialogueStart;
        dialogueEndChannel.OnVoidEventRequested -= HandleDialogueEnd;
    }

    private void HandleDialogueStart(DialogueSO _)
    {
        _currentState = DialogueState;
        _currentState.EnterState(this);
    }

    private void HandleDialogueEnd()
    {
        _currentState = FreeroamState;
        _currentState.EnterState(this);
    }
}
