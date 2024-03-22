using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    private PlayerBaseState currentState;
    public PlayerFreeroamState FreeroamState = new PlayerFreeroamState();
    public PlayerInDialogueState DialogueState = new PlayerInDialogueState();

    [Header("Listening to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;
    [SerializeField] private VoidEventChannelSO dialogueEndChannel;
    void Start()
    {
        currentState = FreeroamState;
        currentState.EnterState(this);
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
        currentState = DialogueState;
        currentState.EnterState(this);
    }

    private void HandleDialogueEnd()
    {
        currentState = FreeroamState;
        currentState.EnterState(this);
    }
}
