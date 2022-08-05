using UnityEngine.InputSystem;

namespace Systems.GameManager.ModeSwitcher
{
    public class OnPauseSwitchToMenu : ModeSwitcher 
    {
        protected override void OnPausePressed(InputAction.CallbackContext context)
        {
            SwitchToUI();
        }
    }
}