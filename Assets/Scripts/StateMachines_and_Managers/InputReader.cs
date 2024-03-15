using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private ActionMapChangeChannelSO actionMapChangeChannel;
    private static InputReader instance;
    public static InputReader Instance => instance;

    public PlayerInputActions playerInputActions { get; private set; }
    public InputActionMap currentMap {get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            playerInputActions = new PlayerInputActions();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        EnableMap(playerInputActions.Player);
        Debug.Log(playerInputActions.Player);
    }

    private void EnableMap(InputActionMap map)
    {
        if (!map.enabled)
        {
            currentMap = map;
            Debug.Log($"Changing map to:{map}");
            playerInputActions.Disable();
            map.Enable();
        }
    }

    private void OnEnable()
    {
        actionMapChangeChannel.OnPlayerMap += HandlePlayerMapCallback;
        actionMapChangeChannel.OnDialogueMap += HandleDialogueMapCallback;
    }

    private void OnDisable()
    {
        actionMapChangeChannel.OnPlayerMap -= HandlePlayerMapCallback;
        actionMapChangeChannel.OnDialogueMap -= HandleDialogueMapCallback;
    }

    private void HandlePlayerMapCallback()
    {
        EnableMap(playerInputActions.Player);
    }

    private void HandleDialogueMapCallback()
    {
        EnableMap(playerInputActions.Dialogue);
    }
}
