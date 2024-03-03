using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityForce = -9.81f;
    [SerializeField] private float sensitivity = 0.5f;
    [SerializeField] private float yRotationLimit = 80f;

    private Vector3 direction;
    private Vector2 movementInput;
    private Vector2 mousePosition;
    private Vector2 mouseTurn = Vector2.zero;
    private bool isGrounded;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;
        movementInput = movement.ReadValue<Vector2>();
        direction = new Vector3(movementInput.x, gravityForce, movementInput.y);
        mousePosition = playerInputActions.Player.MousePosition.ReadValue<Vector2>();


        // TODO: CLEAN UP METHODS LATER PLEASE
        // Movement
        characterController.Move(direction * Time.deltaTime * playerSpeed);

        // Turnds object to movement vector direction
        // if (direction != Vector3.zero)
        // {
        //     gameObject.transform.forward = direction;
        // }

        // Gravity stuff
        if (isGrounded && direction.y < 0)
        {
            direction.y = 0f;
        }

        // Cam rotation
        mouseTurn.x += Input.GetAxis("Mouse X") * sensitivity;
        mouseTurn.y += Input.GetAxis("Mouse Y") * sensitivity;
        mouseTurn.y = Mathf.Clamp(mouseTurn.y, -yRotationLimit, yRotationLimit);

        var xQuat = Quaternion.AngleAxis(mouseTurn.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(mouseTurn.y, Vector3.left);
        transform.localRotation = xQuat * yQuat;

        // Debug. Delete later
        Debug.Log($"Movement vector: {movement.ReadValue<Vector2>()}");
        Debug.Log($"Is grounded: {isGrounded}");
        Debug.Log($"Mouse position: {mousePosition}");
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Move;
        movement.Enable();

        playerInputActions.Player.Jump.performed += OnJump;
        playerInputActions.Player.Jump.Enable();

        playerInputActions.Player.MousePosition.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player.Jump.performed -= OnJump;
        playerInputActions.Player.Jump.Disable();
        playerInputActions.Player.MousePosition.Disable();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        return;
    }


}

