using Systems.InputSystem;
using UnityEngine;

namespace Systems.GameManager.ModeSwitcher.Subscribers
{
    public class PauseGameOnUI : MonoBehaviour
    {
        private void OnEnable()
        {
            InputDriver.changeModeEvent += OnEventChange;
        }

        private void OnDisable()
        {
            InputDriver.changeModeEvent -= OnEventChange;
        }

        private void OnEventChange(UserMode mode)
        {
            if (mode == UserMode.UI)
            {
                Time.timeScale = 0;
            }
        }
    }
}
