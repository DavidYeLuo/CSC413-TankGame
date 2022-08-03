using Systems.InputSystem;
using UnityEngine;

namespace UI
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