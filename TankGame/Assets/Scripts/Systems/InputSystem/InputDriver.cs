using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.InputSystem
{
    public class InputDriver : MonoBehaviour
    {
        public delegate void changeMode(UserMode _mode);
        public static event changeMode changeModeEvent;

        private static InputDriver instance;
        
        [SerializeField] private UserMode mode;

        private static PlayerControls controls; // Other classes will use this
        
        private Dictionary<int, PlayerInput> playerInputDictionary;

        private void Awake()
        {
            if (instance == null)
            {
                controls = new PlayerControls();
                playerInputDictionary = new Dictionary<int, PlayerInput>();
                instance = this;
            }
            else
            {
                Destroy(this);
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

        public void AddControl(int playerNum, PlayerInput input)
        {
            playerInputDictionary.Add(playerNum, input);
        }

        public void RemoveControl(int playerNum)
        {
            playerInputDictionary.Remove(playerNum);
        }
        public bool TryGetValue(int playerIndex, out PlayerInput input)
        {
            return playerInputDictionary.TryGetValue(playerIndex, out input);
        }

        public static PlayerControls GetControls()
        {
            return controls;
        }
        
        public void EnablePlayerJoin()
        {
            PlayerInputManager.instance.EnableJoining();
        }
        public void DisablePlayerJoin()
        {
            PlayerInputManager.instance.DisableJoining();
        }


        public void SwitchToUIMode()
        {
            controls.UI.Enable();
            controls.Gameplay.Disable();
            mode = UserMode.UI;

            if (changeModeEvent == null) return;
            changeModeEvent.Invoke(mode);
            
            // Cursor.lockState = CursorLockMode.None; // TODO: Do testing on locking cursor
        }

        public void SwitchToGameplayMode()
        {
            controls.UI.Disable();
            controls.Gameplay.Enable();
            mode = UserMode.Gameplay;
            
            if (changeModeEvent == null) return;
            changeModeEvent.Invoke(mode);
        }
        
        // TODO: Do testing on locking cursor
        // private void OnApplicationFocus(bool hasFocus)
        // {
        //     if(hasFocus && mode == UserMode.Gameplay)
        //         Cursor.lockState = CursorLockMode.Confined;
        // }
    }
    public enum UserMode 
    {
        UI,
        Gameplay
    }
}