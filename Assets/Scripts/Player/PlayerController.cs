using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    private CharacterController characterController;
    private Camera playerCam;

    [Header("Broadcasting to:")]
    [SerializeField] private VoidEventChannelSO pauseChannel;

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
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerCam = GetComponentInChildren<Camera>();
        
    }

    private void Update()
    {
        if (PlayerStateManager.Instance.currentState == PlayerStateManager.Instance.FreeroamState)
        {
            HandleMovement();
            HandleMouse();
        }
    }

    private void HandleMouse()
    {
        // TODO: set delta as input action
        mouseDelta = Mouse.current.delta.ReadValue();

        mouseTurn.x += mouseDelta.x * sensitivity * Time.deltaTime;
        mouseTurn.y -= mouseDelta.y * sensitivity * Time.deltaTime;
        mouseTurn.y = Mathf.Clamp(mouseTurn.y, -yRotationLimit, yRotationLimit);

        playerCam.transform.localRotation = Quaternion.Euler(mouseTurn.y, 0f, 0f);
        transform.rotation = Quaternion.AngleAxis(mouseTurn.x, Vector3.up);
    }

    private void HandleMovement()
    {
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
        inputReader.MoveEvent += OnMove;

        inputReader.JumpEvent += OnJump;
        inputReader.SprintStartEvent += OnSprint;
        inputReader.SprintEndEvent += OnSprintStop;
        inputReader.PasueEvent += OnPauseButtonPress;

    }

    private void OnDisable()
    {
        inputReader.MoveEvent -= OnMove;
        inputReader.JumpEvent -= OnJump;
        inputReader.SprintStartEvent -= OnSprint;
        inputReader.SprintEndEvent -= OnSprintStop;
        inputReader.PasueEvent -= OnPauseButtonPress;
    }

    private void OnMove(Vector2 vector)
    {
        movementInput = vector;
    }

    private void OnJump()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityForce);
        }
        Debug.Log("Jump");
    }

    private void OnSprint()
    {
        isSprinting = true;
        Debug.Log("Starting Sprint");
    }

    private void OnSprintStop()
    {
        isSprinting = false;
        Debug.Log("Stopping Sprint");
    }

    private void OnPauseButtonPress()
    {
        pauseChannel.RaiseEvent();
    }
}

