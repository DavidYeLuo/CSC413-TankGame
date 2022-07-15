using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Movement;
using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretMovement : MovementDriver
{
    [SerializeField] private GameObject turret;
    
    private InputAction lookControl;

    private void Start()
    {
        lookControl = InputDriver.GetControls().Gameplay.Look;
        lookControl.performed += OnLook;
    }

    private void OnLook(InputAction.CallbackContext callback)
    {
        Move(callback.ReadValue<Vector2>());
    }

    public override void Move(Vector2 direction)
    {
        Vector3 lookRotation = Vector3.up * direction.x + Vector3.left * direction.y;
        turret.transform.Rotate(lookRotation);
    }
}
