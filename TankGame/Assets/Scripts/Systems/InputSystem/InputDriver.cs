using System.Collections.Generic;
using ScriptableObjects;
using Systems.InputSystem.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.InputSystem
{
    public class InputDriver : MonoBehaviour, ISavePlayerControl
    {
        [Header("System Asset")]
        [SerializeField] private SystemAsset systemAsset;
        private PlayerInputsReference playerInputDictionary;
        // Observer pattern
        public delegate void changeMode(UserMode _mode);
        public static event changeMode changeModeEvent;
        
        [Tooltip("Debug purpose")]
        [SerializeField] private UserMode mode;

        // For the most part we don't use masterControl for gameplay.
        // It is mainly used for UI.
        private static PlayerControls masterControl; // This can pick up any device press.

        private void Awake()
        {
            if(masterControl == null)
                masterControl = new PlayerControls();

            playerInputDictionary = systemAsset.GetPlayerInputsAsset();
            foreach (var playerInput in playerInputDictionary.GetPlayerInputs())
            {
                if(playerInput == null) Debug.Log("PlayerInput is null");
            }
        }

        private void OnEnable()
        {
            masterControl.Enable();
        }

        private void OnDisable()
        {
           masterControl.Disable(); 
        }

        public void AddControl(PlayerInput input)
        {
            playerInputDictionary.AddControl(input);
        }

        public void RemoveControl(int playerNum)
        {
            playerInputDictionary.RemoveControl(playerNum);
        }

        public List<PlayerInput> GetAllPlayerInputs()
        {
            return playerInputDictionary.GetPlayerInputs();
        }

        public static PlayerControls GetControls()
        {
            return masterControl;
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
            masterControl.UI.Enable();
            masterControl.Gameplay.Disable();
            mode = UserMode.UI;

            if (changeModeEvent == null) return;
            changeModeEvent.Invoke(mode);
            
            // Cursor.lockState = CursorLockMode.None; // TODO: Do testing on locking cursor
        }

        public void SwitchToGameplayMode()
        {
            masterControl.UI.Disable();
            masterControl.Gameplay.Enable(); // TODO: Maybe decide not to use the master control on gameplay
            mode = UserMode.Gameplay;
            
            if (changeModeEvent == null) return;
            changeModeEvent.Invoke(mode);
        }

        public void SavePlayersControl()
        {
            foreach (var input in playerInputDictionary.GetPlayerInputs())
            {
                DontDestroyOnLoad(input);
            }
            // systemAsset.SetPlayerInputs(playerInputDictionary);
            // systemAsset.SetAsset(playerInputDictionary); // TODO: Fix
            playerInputDictionary.SavePlayersControl();
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