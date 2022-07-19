using Systems.InputSystem;
using UnityEngine;

namespace UI
{
    public class ModeSwitcher : MonoBehaviour
    {
        public void SwitchToGameplayMode()
        {
            InputController.SwitchMode(UserMode.Gameplay);
        }

        public void SwitchToUIMode()
        {
            InputController.SwitchMode(UserMode.UI);
        }
    }
}
