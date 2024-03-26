using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, PlayerInputActions.IPlayerActions, PlayerInputActions.IUIActions
{
    private PlayerInputActions _inputActions;
    private InputActionMap _currentMap;
    public InputActionMap currentMap => _currentMap;
    
    // events
    public event Action<Vector2> MoveEvent;
    public event Action<Vector2> MouseDeltaEvent;
    public event Action JumpEvent;
    public event Action PasueEvent;
    public event Action UnpauseEvent;
    public event Action SprintStartEvent;
    public event Action SprintEndEvent;
    public event Action InteractEvent;
    public event Action MouseClickEvent;

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Player.SetCallbacks(this);
            _inputActions.UI.SetCallbacks(this);
            SetActiveMap(_inputActions.Player);
        }

#if UNITY_EDITOR
        _inputActions.Player.Pause.ApplyBindingOverride("<Keyboard>/tab", path: "<Keyboard>/escape");
        _inputActions.UI.Unpause.ApplyBindingOverride("<Keyboard>/tab", path: "<Keyboard>/escape");
#endif

    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            InteractEvent?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            JumpEvent?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        MouseDeltaEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PasueEvent?.Invoke();
            SetActiveMap(_inputActions.UI);
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            SprintStartEvent?.Invoke();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            SprintEndEvent?.Invoke();
        }
    }

    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            MouseClickEvent?.Invoke();
        }
    }

    public void OnUnpause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            UnpauseEvent?.Invoke();
            SetActiveMap(_inputActions.Player);
        }
    }

    private void SetActiveMap(InputActionMap map)
    {
        _inputActions.Disable();
        _currentMap = map;
        map.Enable();
    }


}
