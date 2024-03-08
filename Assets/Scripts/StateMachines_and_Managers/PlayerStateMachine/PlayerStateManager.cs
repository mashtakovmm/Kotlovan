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
    }

    private void OnDisable()
    {
        dialogueStartChannel.OnDialogueSOEventRequested -= HandleDialogueStart;
    }

    private void HandleDialogueStart(DialogueSO _)
    {
        currentState = DialogueState;
        currentState.EnterState(this);
    }
}
