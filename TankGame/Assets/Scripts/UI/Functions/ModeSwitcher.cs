using System;
using Systems.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI.Functions
{
    // TODO: Remove this class
    public class ModeSwitcher : MonoBehaviour
    {
        [SerializeField] private InputController inputController;
        private PlayerControls masterControl;

        private void OnEnable()
        {
            if(masterControl == null)
                masterControl = InputDriver.GetControls();
            masterControl.Gameplay.Pause.performed += OnPausePressed;
        }
        private void OnDisable()
        {
            masterControl.Gameplay.Pause.performed -= OnPausePressed;
        }

        /** Intended to be overriden **/
        protected virtual void OnPausePressed(InputAction.CallbackContext context)
        {
            
        }

        public void SwitchToUI()
        {
            inputController.SwitchMode(UserMode.UI);
        }
        public void SwitchToGameplay()
        {
            inputController.SwitchMode(UserMode.Gameplay);
        }
    }
}
