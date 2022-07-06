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

        [SerializeField] private UserMode userMode;
            
        private MovementDriver driver;

        private void Awake()
        {
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            controls.Gameplay.Enable();
            InputDriver.changeEvent += OnUpdateUserMode;
        }

        private void OnDisable()
        {
            controls.Gameplay.Disable();
            InputDriver.changeEvent -= OnUpdateUserMode;
        }

        private void Start()
        {
            driver = GetComponent<MovementDriver>();
            moveControl = controls.Gameplay.Move;
        }

        private void FixedUpdate()
        {
            if (!isUsingIO || userMode != UserMode.Gameplay) return;
            Move(moveControl.ReadValue<Vector2>());
        }

        public void Move(Vector2 direction)
        {
            if (direction == null) return;
            driver.Move(direction);
        }
        
        private void OnUpdateUserMode(UserMode mode)
        {
            this.userMode = mode;
        }
    }
}