using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Movement;
using Systems.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class AxisRotationMovement : Movement
{
    [Header("User Settings")] 
    [SerializeField] private float horizontalSensitivity;
    [SerializeField] private float verticalSensitivity;
    [Header("Developer Settings")]
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
            lookRotation += Vector3.up * direction.x * horizontalSensitivity;
        if (!lockVerticalRot)
            lookRotation += turret.transform.right * direction.y * -1 * verticalSensitivity;
        if (lookRotation == Vector3.zero) return;
        rb.AddTorque(lookRotation * Time.deltaTime, ForceMode.Impulse);
    }
}
