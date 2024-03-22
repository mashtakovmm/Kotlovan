using UnityEngine;

/// <summary>
/// This script maanges UI by sending events on channels to toggle UI elements.
/// It also listents to event channels 
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [Header("Channels")]
    [Header("Listening to:")]
    [SerializeField] private VoidEventChannelSO pauseChannel;
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;
    [SerializeField] private VoidEventChannelSO dialogueEndChannel;

    [Header("Broadcasting to:")]
    [SerializeField] private DialogueSOEventChannelSO dialogueActivatedChannel;

    [Header("UI Components")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject dialogueUI;

    private void OnEnable()
    {
        pauseChannel.OnVoidEventRequested += HandlePause;
        dialogueStartChannel.OnDialogueSOEventRequested += OnDialogueStart;
        dialogueEndChannel.OnVoidEventRequested += OnDialogueEnd;

        inputReader.UnpauseEvent += HandleUnpause;
    }

    private void OnDisable()
    {
        pauseChannel.OnVoidEventRequested -= HandlePause;
        dialogueStartChannel.OnDialogueSOEventRequested -= OnDialogueStart;
        dialogueEndChannel.OnVoidEventRequested -= OnDialogueEnd;

        inputReader.UnpauseEvent -= HandleUnpause;
    }

    private void HandlePause()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void HandleUnpause()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDialogueStart(DialogueSO dialogue)
    {
        dialogueUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;

        dialogueActivatedChannel.OnDialogueSOEventRequested(dialogue);


    }

    private void OnDialogueEnd()
    {
        dialogueUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


}
