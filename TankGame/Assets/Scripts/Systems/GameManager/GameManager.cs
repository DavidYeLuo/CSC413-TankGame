using System;
using System.Collections;
using Systems.InputSystem;
using Systems.PlayerCreation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private InputDriver inputDriver;
        [SerializeField] private PlayerCreator playerCreator;
        
        // Test
        [Header("Test")]
        [SerializeField] private GameObject player;

        [SerializeField] private PlayerInput _input;

        private void Start()
        {
            StartCoroutine(LetPlayerJoinForSeconds(5f));
            StartCoroutine(TryToGetControllerAfterSeconds(6f));
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
            PlayerInput input;
            if (inputDriver.TryGetValue(0, out input))
            {
                _input = input;
            }
        }

        private IEnumerator CreatePlayerAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            player = playerCreator.Init(playerPrefab, _input);
        }
    }
}