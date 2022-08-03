using System;
using Systems.InputSystem;
using UnityEngine;

namespace Systems.GameManager
{
    public class CaptureMouseOnGameplay : MonoBehaviour
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
            if (mode == UserMode.Gameplay)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}