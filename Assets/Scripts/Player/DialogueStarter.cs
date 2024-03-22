using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    private Camera playerCamera;
    [SerializeField] private float raycastDistance = 3f;
    private GameObject hitObject;
    private GameObject prevHitObject = null;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            hitObject = hit.collider.gameObject;
            DialogueHaver dialogueHaver = hitObject.GetComponent<DialogueHaver>();

            if (dialogueHaver) { dialogueHaver.Hightlight(); }

            if (prevHitObject != hitObject)
            {
                if (prevHitObject && prevHitObject.GetComponent<DialogueHaver>())
                {
                    prevHitObject.GetComponent<DialogueHaver>().StopHighlight();
                }
            }

            prevHitObject = hitObject;
        }
        else if (prevHitObject)
        {
            if (prevHitObject && prevHitObject.GetComponent<DialogueHaver>())
            {
                prevHitObject.GetComponent<DialogueHaver>().StopHighlight();
            }
            prevHitObject = null;
        }
    }

    private void OnEnable()
    {
        inputReader.InteractEvent += HandleInteract;
    }

    private void OnDisable()
    {
        inputReader.InteractEvent -= HandleInteract;
    }

    private void HandleInteract()
    {
        if (hitObject && hitObject.GetComponent<DialogueHaver>())
        {
            hitObject.GetComponent<DialogueHaver>().HandleDialogueRequest();
        }
    }

}

