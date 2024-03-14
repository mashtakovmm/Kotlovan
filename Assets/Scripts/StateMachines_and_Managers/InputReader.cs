using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private static InputReader instance;
    public static InputReader Instance
    {
        get
        {
            if (!instance)
            {
                instance = new GameObject("InputReader Singleton", typeof(InputReader)).GetComponent<InputReader>();
                instance.playerInputActions = new PlayerInputActions();
            }

            return instance;
        }
    }

    public PlayerInputActions playerInputActions { get; private set; }

    void Start()
    {

    }


    void Update()
    {

    }
}
