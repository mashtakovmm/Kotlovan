using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueStarter : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Camera playerCamera;
    [SerializeField] private float raycastDistance = 3f;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerCamera = GetComponentInChildren<Camera>();
        Debug.Log(playerInputActions);
    }

    private void Update()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {

        }
    }

    private void OnEnable()
    {
        playerInputActions.Player.Interact.Enable();
        playerInputActions.Player.Interact.performed += HandleInteract;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Interact.Disable();
        playerInputActions.Player.Interact.performed -= HandleInteract;
    }

    private void HandleInteract(InputAction.CallbackContext context)
    {

    }

}

