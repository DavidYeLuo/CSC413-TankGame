using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(MovementDriver))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private bool shouldInjectControl;

        private InputAction moveControl;
            
        private MovementDriver driver;

        private void Start()
        {
            driver = GetComponent<MovementDriver>();
            // moveControl = controls.Gameplay.Move;
            moveControl = InputDriver.GetControls().Gameplay.Move;
        }

        private void FixedUpdate()
        {
            if (!shouldInjectControl) return;
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