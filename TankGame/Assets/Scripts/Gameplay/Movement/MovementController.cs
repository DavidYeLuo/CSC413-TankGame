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
            moveControl.performed += OnMove;
            moveControl.canceled += OnMove;
        }

        private void OnMove(InputAction.CallbackContext callback)
        {
            Move(callback.ReadValue<Vector2>());
        }

        public void Move(Vector2 direction)
        {
            if (direction == null) return;
            driver.Move(direction);
        }
    }
}