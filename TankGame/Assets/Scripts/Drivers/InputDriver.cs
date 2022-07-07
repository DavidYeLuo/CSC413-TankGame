using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drivers
{
    public class InputDriver : MonoBehaviour
    {
        [SerializeField] private UserMode mode;

        private static PlayerControls controls; // Other classes will use this

        private void Awake()
        {
            if (controls == null)
            {
                controls = new PlayerControls();
            }
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
           controls.Disable(); 
        }

        public static PlayerControls GetControls()
        {
            return controls;
        }

        public void SwitchToUIMode()
        {
            controls.UI.Enable();
            controls.Gameplay.Disable();
            mode = UserMode.UI;
        }

        public void SwitchToGameplayMode()
        {
            controls.UI.Disable();
            controls.Gameplay.Enable();
            mode = UserMode.Gameplay;
        }
    }
    public enum UserMode 
    {
        UI,
        Gameplay
    }
}