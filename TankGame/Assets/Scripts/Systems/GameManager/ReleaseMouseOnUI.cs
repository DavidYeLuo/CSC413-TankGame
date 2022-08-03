using Systems.InputSystem;
using UnityEngine;

namespace Systems.GameManager
{
    public class ReleaseMouseOnUI : MonoBehaviour
    {
        private void OnEnable()
        {
            InputDriver.changeModeEvent += OnGameplay;
        }

        private void OnDisable()
        {
            InputDriver.changeModeEvent -= OnGameplay;
        }

        private void OnGameplay(UserMode mode)
        {
            if (mode == UserMode.UI)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}