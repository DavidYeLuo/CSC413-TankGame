using Systems.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.GameManager.ModeSwitcher
{
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

        protected void SwitchToUI()
        {
            inputController.SwitchMode(UserMode.UI);
        }
        protected void SwitchToGameplay()
        {
            inputController.SwitchMode(UserMode.Gameplay);
        }
    }
}
