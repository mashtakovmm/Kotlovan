using UnityEngine;

/// <summary>
/// This script maanges UI by sending events on channels to toggle UI elements.
/// It also listents to event channels 
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Channels")]
    [Header("Listening to:")]
    [SerializeField] private BoolEventChannelSO pauseChannel;
    [SerializeField] private DialogueSOEventChannelSO dialogueStartChannel;
    [SerializeField] private VoidEventChannelSO dialogueEndChannel;

    [Header("UI Components")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject dialogueUI;

    private void OnEnable()
    {
        pauseChannel.OnBoolEventRequested += HandlePause;
        dialogueStartChannel.OnDialogueSOEventRequested += OnDialogueStart;
    }

    private void OnDisable()
    {
        pauseChannel.OnBoolEventRequested -= HandlePause;
        dialogueStartChannel.OnDialogueSOEventRequested -= OnDialogueStart;
    }

    private void HandlePause(bool isPaused)
    {
        pauseMenu.SetActive(isPaused);
        if (isPaused) { Cursor.lockState = CursorLockMode.Confined; }
        else { Cursor.lockState = CursorLockMode.Locked; }
    }

    private void OnDialogueStart(DialogueSO dialogue)
    {
        dialogueUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDialogueEnd()
    {
        dialogueUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


}
