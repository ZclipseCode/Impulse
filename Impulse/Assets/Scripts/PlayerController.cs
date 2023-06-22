using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask barrierLayer;

    PlayerControls controls;
    float circleOverlap = 0.2f;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Movement.performed += OnMovement;
        controls.Player.Shoot.performed += OnShoot;
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        if (!Physics2D.OverlapCircle(transform.position + new Vector3(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y, 0), circleOverlap, barrierLayer))
        {
            transform.position += new Vector3(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y, 0);
        }
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
