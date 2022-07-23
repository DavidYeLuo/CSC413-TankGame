using System;
using System.Collections;
using System.Collections.Generic;
using Systems.InputSystem;
using Systems.PlayerCreation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SystemAsset systemAsset;
        // TODO: Make a list of player prefabs one mapping to each player.
        // Maybe they want a different color prefab or something.
        [SerializeField] private GameObject playerPrefab;
        
        [Header("Drivers")]
        [SerializeField] private InputDriver inputDriver;
        [SerializeField] private PlayerCreator playerCreator;
        
        // TODO: Make a list of transforms for random spawn points.
        
        // Test
        [Header("For Debugging")]
        [SerializeField] private List<GameObject> playerList;
        [SerializeField] private List<PlayerInput> playerInputList;

        private void Start()
        {
            // Loads data from systemAsset and use them.
            Dictionary<int, PlayerInput> playerInputs = systemAsset.GetPlayerInputs();
            foreach (var keyValuePair in playerInputs)
            {
                Debug.LogFormat("Key: <{0}>, Value: <{1}>", keyValuePair.Key, keyValuePair.Value.currentControlScheme);
                playerCreator.SetSpawnPosition(new Vector3(keyValuePair.Key * 20,5,keyValuePair.Key * 20));
                playerCreator.Init(playerPrefab, keyValuePair.Value);
            }
        }
    }
}