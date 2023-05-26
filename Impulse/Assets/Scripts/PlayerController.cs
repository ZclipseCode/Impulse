using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float tileSize;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = new PlayerMovement();

        playerMovement.Player.Movement.performed += DoMovement;
        playerMovement.Player.Shoot.performed += DoShoot;
    }

    private void OnEnable()
    {
        playerMovement.Player.Movement.Enable();
        playerMovement.Player.Shoot.Enable();
    }

    private void DoMovement(InputAction.CallbackContext context)
    {
        if (GameController.gameState == States.PLAYER)
        {
            transform.position += new Vector3(playerMovement.Player.Movement.ReadValue<Vector2>().x, playerMovement.Player.Movement.ReadValue<Vector2>().y);

            GameController.playerTurnHandler?.Invoke();
        }
    }

    private void DoShoot(InputAction.CallbackContext context)
    {
        if (GameController.gameState == States.PLAYER)
        {
            Debug.Log("shoot");

            GameController.playerTurnHandler?.Invoke();
        }
    }

    private void OnDisable()
    {
        playerMovement.Player.Movement.Disable();
        playerMovement.Player.Shoot.Disable();
    }

    private void OnDestroy()
    {
        playerMovement.Player.Movement.performed -= DoMovement;
        playerMovement.Player.Shoot.performed -= DoShoot;
    }
}
