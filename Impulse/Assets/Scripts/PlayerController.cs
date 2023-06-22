using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Movement.performed += OnMovement;
        controls.Player.Shoot.performed += OnShoot;
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        //if (Mathf.Abs(context.ReadValue<Vector2>().x) > 0)
        //{
        //    transform.position += new Vector3(context.ReadValue<Vector2>().x, 0, 0);
        //}
        //else if (Mathf.Abs(context.ReadValue<Vector2>().y) > 0)
        //{
        //    transform.position += new Vector3(context.ReadValue<Vector2>().y, 0, 0);
        //}
        transform.position += new Vector3(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y, 0);
    }

    void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void OnDestroy()
    {
        controls.Player.Movement.performed -= OnMovement;
        controls.Player.Shoot.performed -= OnShoot;
    }
}
