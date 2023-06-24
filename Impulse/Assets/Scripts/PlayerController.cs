using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Movement
{
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Movement.performed += OnMovement;
        controls.Player.Shoot.performed += OnShoot;
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        MoveAdjacent(context.ReadValue<Vector2>());
    }

    void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
    }

    private void OnDestroy()
    {
        controls.Disable();
        controls.Player.Movement.performed -= OnMovement;
        controls.Player.Shoot.performed -= OnShoot;
    }
}
