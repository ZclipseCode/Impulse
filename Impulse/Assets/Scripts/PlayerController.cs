using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = new PlayerMovement();
    }

    private void OnEnable()
    {
        playerMovement.Player.Movement.performed += DoMovement;
        playerMovement.Player.Movement.Enable();

        playerMovement.Player.Shoot.performed += DoShoot;
        playerMovement.Player.Shoot.Enable();
    }

    private void DoMovement(InputAction.CallbackContext context)
    {
        Debug.Log(playerMovement.Player.Movement.ReadValue<Vector2>());
    }

    private void DoShoot(InputAction.CallbackContext context)
    {
        Debug.Log("shoot");
    }

    private void OnDisable()
    {
        playerMovement.Player.Movement.Disable();
        playerMovement.Player.Shoot.Disable();
    }
}
