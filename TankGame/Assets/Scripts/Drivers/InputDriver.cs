using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drivers
{
    public class InputDriver : MonoBehaviour
    {
        public delegate void ChangeMode(UserMode mode);
        public static event ChangeMode changeEvent;
        
        [SerializeField] private UserMode mode;

        private PlayerControls controls;

        public void SwitchToUIMode()
        {
            mode = UserMode.UI;
            changeEvent.Invoke(mode);
        }

        public void SwitchToGameplayMode()
        {
            mode = UserMode.Gameplay;
            changeEvent.Invoke(mode);
        }
    }
    public enum UserMode 
    {
        UI,
        Gameplay
    }
}