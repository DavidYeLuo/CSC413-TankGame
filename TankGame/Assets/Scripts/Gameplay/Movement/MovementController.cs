using System;
using Gameplay.Movement.Tank;
using Systems.InputSystem;
using Systems.PlayerCreation.Helpers;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(Movement))]
    public class MovementController : MonoBehaviour, IRequireController
    {
        [Tooltip("Action button for moving. NOTE: Spelling matters.")]
        [SerializeField] private string nameOfMoveAction;
        private InputAction moveControl;

        private Movement driver;

        private void Start()
        {
            driver = GetComponent<MovementDriver>();
            if (moveControl == null) // By default: It will use the master control
            {
                moveControl = InputDriver.GetControls().Gameplay.Move;
                SubscribeMoveAction();
            }
        }

        private void OnEnable()
        {
            if (moveControl == null) return; // Needed since this is also called before start() 
            SubscribeMoveAction();
        }

        private void OnDisable()
        {
            UnsubscribeMoveAction();
        }

        private void OnMove(InputAction.CallbackContext callback)
        {
            Move(callback.ReadValue<Vector2>());
        }

        public void Move(Vector2 direction)
        {
            driver.Move(direction);
        }

        private void SubscribeMoveAction()
        {
            moveControl.performed += OnMove;
            moveControl.canceled += OnMove;
        }
        private void UnsubscribeMoveAction()
        {
            moveControl.performed -= OnMove;
            moveControl.canceled -= OnMove;
        }

        public void GetController(InputActionMap map)
        {
            if (moveControl != null)
            {
                // Override the current control
                UnsubscribeMoveAction();
            }
            moveControl = InputActionHelper.GetInputAction(map, nameOfMoveAction);
            SubscribeMoveAction();
        }
    }
}