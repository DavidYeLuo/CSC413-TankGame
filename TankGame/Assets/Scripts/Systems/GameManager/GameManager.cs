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
            return;
            // To simulate the UI Scene.
            StartCoroutine(LetPlayerJoinForSeconds(5f));
            StartCoroutine(TryToGetControllerAfterSeconds(6f));
            
            // This will be called in the gameplay scene.
            StartCoroutine(CreatePlayerAfterSeconds(7f));
        }

        private IEnumerator LetPlayerJoinForSeconds(float seconds)
        {
            inputDriver.EnablePlayerJoin();
            yield return new WaitForSeconds(seconds);
            inputDriver.DisablePlayerJoin();
        }

        private IEnumerator TryToGetControllerAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            playerInputList = inputDriver.GetAllPlayerInputs();
        }

        private IEnumerator CreatePlayerAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            foreach (var input in playerInputList)
            {
                playerList.Add(playerCreator.Init(playerPrefab, input));
            }
        }
    }
}