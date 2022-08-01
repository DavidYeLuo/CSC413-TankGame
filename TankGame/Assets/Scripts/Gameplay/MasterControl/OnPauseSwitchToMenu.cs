using UI.Functions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace.Gameplay.MasterControl
{
    public class OnPauseSwitchToMenu : ModeSwitcher 
    {
        protected override void OnPausePressed(InputAction.CallbackContext context)
        {
            SwitchToUI();
        }
    }
}