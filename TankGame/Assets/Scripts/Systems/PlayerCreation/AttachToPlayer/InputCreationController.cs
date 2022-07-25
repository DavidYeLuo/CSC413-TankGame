using System;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.PlayerCreation.AttachToPlayer
{
    [RequireComponent(typeof(CreationDriver))]
    public class InputCreationController : MonoBehaviour, IInitController
    {
        [SerializeField] private string actionMapName;

        private PlayerInput playerInput;
    
        [Header("Runtime Debug")]
        [SerializeField] private InputActionMap map;
        private void Init(InputActionMap map)
        {
            if (map == null) throw new Exception("InputCreationController: map is null.");
            (GetComponent<CreationDriver>()).Init(map);
        }

        // Should belong to the driver class
        private InputActionMap GetMap(string actionMapName)
        {
            // Ugly code but my only understanding to implement local multiplayer.
            // The reason why I added exception is for debugging purpose.
            // Since we need to access the variables we want through strings,
            // there is a chance of a misspelling error as a programmer.
            // Possible misspellings: actionMapName or actionName
            if (playerInput == null) throw new Exception("InputCreationController: Player InputController isn't found.");
            InputActionAsset inputAsset = playerInput.actions;
            if (inputAsset == null) throw new Exception("InputCreationController: Player InputActionAsset is null.");
            InputActionMap gameplayMap = inputAsset.FindActionMap(actionMapName);
            if (gameplayMap == null) throw new Exception("InputCreationController: Player ActionMap isn't found.");
            map = gameplayMap;

            return gameplayMap;
        }

        public void InitController(PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            Init(GetMap(this.actionMapName));
        }
    }
}
