using System;
using Gameplay.Movement.Tank;
using Systems.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(Movement))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private bool shouldInjectControl;

        private InputAction moveControl;
            
        private Movement driver;

        private void Start()
        {
            driver = GetComponent<TankMovementDriver>();
            // moveControl = controls.Gameplay.Move;
            moveControl = InputDriver.GetControls().Gameplay.Move;
            moveControl.performed += OnMove;
            moveControl.canceled += OnMove;
        }

        private void OnEnable()
        {
            if (moveControl == null) return; // Needed since this is also called before start() 
            moveControl.performed += OnMove;
            moveControl.canceled += OnMove;
        }

        private void OnDisable()
        {
            moveControl.performed -= OnMove;
            moveControl.canceled -= OnMove;
        }

        private void OnMove(InputAction.CallbackContext callback)
        {
            Move(callback.ReadValue<Vector2>());
        }

        public void Move(Vector2 direction)
        {
            driver.Move(direction);
        }
    }
}