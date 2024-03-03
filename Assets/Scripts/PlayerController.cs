using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction movement;
    private CharacterController characterController;

    // TODO: jumping and rotating with mouse

    // Controls values
    [SerializeField] private float normalSpeed = 2.0f;
    [SerializeField] private float sprintSpeed = 3.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityForce = -9.81f;
    private Vector3 move;
    private Vector2 movementInput;
    private Vector3 verticalVelocity;

    private float speed;

    private bool isSprinting;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movementInput = movement.ReadValue<Vector2>();
        move = transform.right * movementInput.x + transform.forward * movementInput.y;

        // Gravity stuff
        verticalVelocity.y += gravityForce * Time.deltaTime;

        if (characterController.isGrounded && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -1f;
        }

        // TODO: CLEAN UP METHODS LATER PLEASE

        // Movement
        if (isSprinting)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        characterController.Move(move * Time.deltaTime * speed);
        characterController.Move(verticalVelocity * Time.deltaTime);

        // Debug. Delete later
        Debug.Log($"Is grounded: {characterController.isGrounded}");
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Move;

        playerInputActions.Player.Jump.performed += OnJump;
        playerInputActions.Player.Sprint.performed += OnSprint;
        playerInputActions.Player.Sprint.canceled += OnSprintStop;

        playerInputActions.Player.Enable();

    }

    private void OnDisable()
    {
        playerInputActions.Player.Jump.performed -= OnJump;
        playerInputActions.Player.Sprint.performed -= OnSprint;
        playerInputActions.Player.Sprint.canceled -= OnSprintStop;

        playerInputActions.Player.Disable();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityForce);
        }
        Debug.Log("Jump");
        return;
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = true;
        Debug.Log("Starting Sprint");
        return;
    }

    private void OnSprintStop(InputAction.CallbackContext context)
    {
        isSprinting = false;
        Debug.Log("Stopping Sprint");
        return;
    }
}

