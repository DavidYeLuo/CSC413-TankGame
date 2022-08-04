using Systems.InputSystem;
using UnityEngine;

namespace Systems.GameManager.ModeSwitcher.Subscribers
{
    public class ResumeGameOnGameplay : MonoBehaviour
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
            if (mode == UserMode.Gameplay)
            {
                Time.timeScale = 1;
            }
        }
    }
}