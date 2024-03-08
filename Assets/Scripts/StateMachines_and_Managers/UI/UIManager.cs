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
    
    [Header("UI Components")]
    [SerializeField] private GameObject pauseMenu;

    private void OnEnable()
    {
        pauseChannel.OnBoolEventRequested += HandlePause;
    }

    private void OnDisable()
    {
        pauseChannel.OnBoolEventRequested -= HandlePause;
    }

    private void HandlePause(bool isPaused)
    {
        pauseMenu.SetActive(isPaused);
    }
}
