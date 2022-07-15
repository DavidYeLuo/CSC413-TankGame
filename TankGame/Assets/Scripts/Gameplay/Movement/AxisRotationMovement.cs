using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Movement;
using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class AxisRotationMovement : MovementDriver
{
    [SerializeField] private bool lockHorizontalRot;
    [SerializeField] private bool lockVerticalRot;
    [SerializeField] private GameObject turret;
    [SerializeField] private Rigidbody rb;
    
    private InputAction lookControl;
    private Vector3 lookRotation;

    private void Start()
    {
        lookControl = InputDriver.GetControls().Gameplay.Look;
        lookControl.performed += OnLook;
        lookControl.canceled += OnCancel;
    }

    private void OnLook(InputAction.CallbackContext callback)
    {
        Move(callback.ReadValue<Vector2>());
    }

    private void OnCancel(InputAction.CallbackContext callback)
    {
        Move(Vector3.zero);
    }

    public override void Move(Vector2 direction)
    {
        lookRotation = Vector3.zero;
        if(!lockHorizontalRot)
            lookRotation += Vector3.up * direction.x;
        if(!lockVerticalRot)
            lookRotation += Vector3.left * direction.y;
        if (lookRotation == Vector3.zero) return;
        turret.transform.Rotate(lookRotation);
    }
}
