using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerInputsAsset", menuName = "Asset/PlayerInputs")]
    public class PlayerInputsReference : ScriptableObject
    {
        public delegate void inputsChanged();
        public event inputsChanged inputsChangeEvent;

        [SerializeField] private List<PlayerInput> playerInputs;

        public void Init()
        {
            playerInputs = new List<PlayerInput>();
        }

        public void AddControl(PlayerInput input)
        {
            playerInputs.Add(input);
            InvokeEvent();
        }

        public void RemoveControl(int playerNum)
        {
            playerInputs.RemoveAt(playerNum);
            InvokeEvent();
        }

        public List<PlayerInput> GetPlayerInputs()
        {
            return playerInputs;
        }
        
        // Unused code. Probably won't need it
        // public void SetPlayerInputs(List<PlayerInput> inputs)
        // {
        //     playerInputs = inputs;
        //     InvokeEvent();
        // }
        
        public void SavePlayersControl()
        {
            foreach (var input in playerInputs)
            {
                DontDestroyOnLoad(input);
            }
            DontDestroyOnLoad(this);
        }

        private void InvokeEvent()
        {
            if (inputsChangeEvent == null) return;
            inputsChangeEvent.Invoke();
        }
    }
}