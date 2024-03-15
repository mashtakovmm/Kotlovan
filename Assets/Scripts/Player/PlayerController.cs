using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputReader inputReader;
    private InputAction movement;
    private CharacterController characterController;
    private Camera playerCam;

    [Header("Broadcasting to:")]
    [SerializeField] private BoolEventChannelSO pauseChannel;

    [Header("Controls")]
    [SerializeField] private float normalSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityForce = -9.81f;

    [Header("Camera rotation")]
    [SerializeField] private float sensitivity = 10f;
    [SerializeField] private float yRotationLimit = 90f;
    private Vector2 mouseDelta;
    private Vector2 mouseTurn = Vector2.zero;

    private Vector3 move;
    private Vector2 movementInput;
    private Vector3 verticalVelocity;

    private float speed;
    private bool isSprinting;

    private bool isPaused = false;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerCam = GetComponentInChildren<Camera>();

        inputReader = FindObjectOfType<InputReader>();
        playerInputActions = inputReader.playerInputActions;

    }

    private void Update()
    {
        HandleMovement();

        if (playerInputActions.Player.enabled)
        {
            HandleMouse();
        }

    }

    private void HandleMouse()
    {
        mouseDelta = Mouse.current.delta.ReadValue();

        mouseTurn.x += mouseDelta.x * sensitivity * Time.deltaTime;
        mouseTurn.y -= mouseDelta.y * sensitivity * Time.deltaTime;
        mouseTurn.y = Mathf.Clamp(mouseTurn.y, -yRotationLimit, yRotationLimit);

        playerCam.transform.localRotation = Quaternion.Euler(mouseTurn.y, 0f, 0f);
        transform.rotation = Quaternion.AngleAxis(mouseTurn.x, Vector3.up);
    }

    private void HandleMovement()
    {
        movementInput = movement.ReadValue<Vector2>();
        move = transform.right * movementInput.x + transform.forward * movementInput.y;

        // Gravity stuff
        verticalVelocity.y += gravityForce * Time.deltaTime;

        if (characterController.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -1f;
        }

        if (isSprinting)
        {
            speed = normalSpeed * 1.5f;
        }
        else
        {
            speed = normalSpeed;
        }

        characterController.Move(move * Time.deltaTime * speed);
        characterController.Move(verticalVelocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Move;

        playerInputActions.Player.Jump.performed += OnJump;
        playerInputActions.Player.Sprint.performed += OnSprint;
        playerInputActions.Player.Sprint.canceled += OnSprintStop;
        playerInputActions.Player.Pause.performed += OnPauseButtonPress;

#if UNITY_EDITOR
        playerInputActions.Player.Pause.ApplyBindingOverride("<Keyboard>/tab", path: "<Keyboard>/escape");
#endif

        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Jump.performed -= OnJump;
        playerInputActions.Player.Sprint.performed -= OnSprint;
        playerInputActions.Player.Sprint.canceled -= OnSprintStop;
        playerInputActions.Player.Pause.performed -= OnPauseButtonPress;

        playerInputActions.Player.Disable();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityForce);
        }
        Debug.Log("Jump");
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = true;
        Debug.Log("Starting Sprint");
    }

    private void OnSprintStop(InputAction.CallbackContext context)
    {
        isSprinting = false;
        Debug.Log("Stopping Sprint");
    }

    private void OnPauseButtonPress(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
        pauseChannel.RaiseEvent(isPaused);
    }
}

