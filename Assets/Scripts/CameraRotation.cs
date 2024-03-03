using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float sensitivity = 10f;
    [SerializeField] private float yRotationLimit = 90f;
    private Vector2 mouseDelta;
    private Vector2 mouseTurn = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseDelta = Mouse.current.delta.ReadValue();

        mouseTurn.x += mouseDelta.x * sensitivity * Time.deltaTime;
        mouseTurn.y -= mouseDelta.y * sensitivity * Time.deltaTime;
        mouseTurn.y = Mathf.Clamp(mouseTurn.y, -yRotationLimit, yRotationLimit);

        transform.localRotation = Quaternion.Euler(mouseTurn.y, 0f, 0f);
        transform.parent.rotation = Quaternion.AngleAxis(mouseTurn.x, Vector3.up);
    }
}
