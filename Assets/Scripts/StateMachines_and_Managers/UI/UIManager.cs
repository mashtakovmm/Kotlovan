using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Listening to:")]
    [SerializeField] BoolEventChannelSO togglePauseMenuChanel;

    [Header("Components")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject interactButtonTip;

    private void OnEnable()
    {
        togglePauseMenuChanel.OnBoolEventRequested += onToggle;
    }

    private void OnDisable()
    {
        togglePauseMenuChanel.OnBoolEventRequested -= onToggle;
    }

    private void onToggle(bool value)
    {
        pauseMenu.SetActive(value);
    }
}
