using Systems.InputSystem;
using Systems.PlayerCreation.Helpers;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(Rotator))]
    public class LookController : MonoBehaviour, IRequireController
    {
        
        [Tooltip("Action button for look. NOTE: Spelling matters.")]
        [SerializeField] private string nameOfLookAction;
        private InputAction moveControl;

        private Rotator driver;

        private void Start()
        {
            if(driver == null) driver = GetComponent<Rotator>();
            if (moveControl == null) // By default: It will use the master control
            {
                moveControl = InputDriver.GetControls().Gameplay.Look;
                SubscribeLookAction();
            }
        }

        private void OnEnable()
        {
            if (driver == null) driver = GetComponent<Rotator>();
            if (moveControl == null) return; // Needed since this is also called before start() 
            SubscribeLookAction();
        }

        private void OnDisable()
        {
            UnsubscribeLookAction();
        }

        private void OnLook(InputAction.CallbackContext callback)
        {
            Look(callback.ReadValue<Vector2>());
        }

        public void Look(Vector2 direction)
        {
            driver.Look(direction);
        }

        private void SubscribeLookAction()
        {
            moveControl.performed += OnLook;
            moveControl.canceled += OnLook;
        }
        private void UnsubscribeLookAction()
        {
            moveControl.performed -= OnLook;
            moveControl.canceled -= OnLook;
        }

        public void GetController(InputActionMap map)
        {
            if (moveControl != null)
            {
                // Override the current control
                UnsubscribeLookAction();
            }
            moveControl = InputActionHelper.GetInputAction(map, nameOfLookAction);
            SubscribeLookAction();
        }
    }
}