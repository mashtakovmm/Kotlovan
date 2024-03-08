using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueStarter : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Camera playerCamera;
    [SerializeField] private float raycastDistance = 3f;
    private GameObject hitObject;
    private GameObject prevHitObject = null;
    private Color defaultColor;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            hitObject = hit.collider.gameObject;
            if (prevHitObject != hitObject)
            {
                if (prevHitObject != null)
                {
                    prevHitObject.GetComponent<Renderer>().material.SetColor("_Color", defaultColor); 
                }
                defaultColor = hitObject.GetComponent<Renderer>().material.GetColor("_Color");
                prevHitObject = hitObject;
                if (hitObject.GetComponent<DialogueHaver>())
                {
                    hitObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                }
            }
        }
        else if (prevHitObject)
        {
            prevHitObject.GetComponent<Renderer>().material.SetColor("_Color", defaultColor); 
            prevHitObject = null;
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
        if (hitObject && hitObject.GetComponent<DialogueHaver>())
        {
            hitObject.GetComponent<DialogueHaver>().HandleDialogueRequest();
        }
    }

}

