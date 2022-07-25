using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Systems.GameManager.Interfaces;
using Systems.InputSystem;
using Systems.PlayerCreation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.GameManager
{
    public class GameManagerDriver : MonoBehaviour, ICreatePlayers
    {
        [SerializeField] private SystemAsset systemAsset;
        // TODO: Make a list of player prefabs one mapping to each player.
        // Maybe they want a different color prefab or something.
        [SerializeField] private GameObject playerPrefab;
        
        [Header("Drivers")]
        [SerializeField] private PlayerCreator playerCreator;
        
        // TODO: Make a list of transforms for random spawn points.
        
        // Test
        [Header("For Debugging")]
        [SerializeField] private List<GameObject> playerList;
        [SerializeField] private List<PlayerInput> playerInputList;

        public void CreatePlayers()
        {
            // Loads data from systemAsset and use them.
            Dictionary<int, PlayerInput> playerInputs = systemAsset.GetPlayerInputs();
            playerList = new List<GameObject>(); // For Debugging
            
            foreach (var keyValuePair in playerInputs)
            {
                // TODO: Use swap method between system and player data to create customized player data.
                playerCreator.SetSpawnPosition(new Vector3(keyValuePair.Key * 20,5,keyValuePair.Key * 20));
                playerCreator.SetSpawnRotation(Quaternion.identity); // Default rotation
                playerList.Add(playerCreator.Init(playerPrefab, keyValuePair.Value));
            }
            
            // For Debugging
            playerInputList = systemAsset.GetPlayerInputs().Values.ToList();
        }
    }
}