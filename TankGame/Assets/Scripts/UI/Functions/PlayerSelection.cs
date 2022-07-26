using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI.Functions
{
    public class PlayerSelection : MonoBehaviour
    {
        [SerializeField] private SystemAsset systemAsset;
        
        [Header("Debug Purpose")]
        [SerializeField] private List<PlayerInput> listOfPlayers;

        public int GetNumberOfPlayersPlaying()
        {
            if (systemAsset.GetPlayerInputs() == null) return 0;
            return systemAsset.GetPlayerInputs().Count;
        }
    }
}