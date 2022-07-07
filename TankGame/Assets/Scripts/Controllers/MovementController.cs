using System;
using Drivers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    [RequireComponent(typeof(MovementDriver))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private bool isUsingIO;

        private PlayerControls controls;
        private InputAction moveControl;
            
        private MovementDriver driver;

        private void Start()
        {
            driver = GetComponent<MovementDriver>();
            // moveControl = controls.Gameplay.Move;
            controls = InputDriver.GetControls();
            moveControl = InputDriver.GetControls().Gameplay.Move;
        }

        private void FixedUpdate()
        {
            if (!isUsingIO) return;
            Move(moveControl.ReadValue<Vector2>());
        }

        public void Move(Vector2 direction)
        {
            if (direction == null) return;
            driver.Move(direction);
        }

        /**
         * TODO: Actually fire something. Right now it is only used to test switch modes.
         */
        private void OnFire()
        { 
            InputController.SwitchMode(UserMode.Gameplay);
        }
    }
}