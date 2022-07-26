using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScriptableObjects
{
    public class PlayerInputsReference : ScriptableObject
    {
        public delegate void valueChanged();
        public event valueChanged valueChangeEvent;
        
        private Dictionary<int, PlayerInput> playerInputs;

        public Dictionary<int, PlayerInput> GetPlayerInputs()
        {
            return playerInputs;
        }

        public void SetPlayerInputs(Dictionary<int, PlayerInput> inputs)
        {
            playerInputs = inputs;
            valueChangeEvent.Invoke();
        }
    }
}