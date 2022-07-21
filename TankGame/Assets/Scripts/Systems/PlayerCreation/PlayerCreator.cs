using System;
using System.Collections.Generic;
using Gameplay.Camera;
using Gameplay.Health;
using Gameplay.Movement;
using ScriptableObjects;
using Systems.CameraSystem;
using Systems.PlayerCreation.Interfaces;
using UI.Health;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.tvOS;

namespace Systems.PlayerCreation
{
    [RequireComponent(typeof(PlayerInputManager))]
    public class PlayerCreator : MonoBehaviour
    {
        [SerializeField] private int numOfPlayers;
        [SerializeField] private GameObject playerPrefab;

        [Header("Player Initial State")]
        [SerializeField] private PlayerAsset playerAsset;
        
        [Header("UI")]
        [SerializeField] private List<Canvas> uiPrefabs;

        // Temporary
        private void NewStart()
        {
            // PlayerInputManager manager = PlayerInputManager.instance;
            // manager.EnableJoining();
            // manager.JoinPlayer(pairWithDevice: Keyboard.current);
            // manager.JoinPlayer(pairWithDevice: Keyboard.current);
        }

        private void OnEnable()
        {
            PlayerInputManager playerInputManager = PlayerInputManager.instance;
            playerInputManager.onPlayerJoined += Init;
        }

        private void OnDisable()
        {
            PlayerInputManager playerInputManager = PlayerInputManager.instance;
            playerInputManager.onPlayerJoined -= Init;
        }

        private void Init(PlayerInput playerInput)
        {
            // Creates a new player
            GameObject workingPlayer = playerInput.gameObject;
            Camera workingCamera = playerInput.camera;
            
            // Sets players to their location
            SpawnLocation(workingPlayer, 0); // Temp
            
            // Creating data for each player. (Have their own data)
            // Preparing to set up dependencies.
            PlayerAsset _playerAsset = Instantiate(playerAsset);
            _playerAsset.DeepCopy(playerAsset);
            
            // Sets up dependencies
            IInitPlayerAsset playerInitializer = workingPlayer.GetComponent<IInitPlayerAsset>();
            IInitController controllerInitializer = workingPlayer.GetComponent<IInitController>();
            
            playerInitializer.InitPlayer(_playerAsset);
            controllerInitializer.InitController();
            
            // Sets up UI and dependencies
            Canvas workingUI;
            GameObject workingUIParent = new GameObject(String.Format("UI_Player_{0}", 0)); // Temp
            foreach (Canvas ui in uiPrefabs)
            {
                // Sets up UI so that it isn't too far(default)
                workingUI = Instantiate(ui);
                workingUI.renderMode = RenderMode.ScreenSpaceCamera;
                workingUI.planeDistance = 1;
                workingUI.worldCamera = workingCamera;

                // Sets up dependencies
                // UI isn't part of the player prefab so we must also initialize it separately.
                playerInitializer = workingUI.GetComponent<IInitPlayerAsset>();
                if(playerInitializer != null)
                    playerInitializer.InitPlayer(_playerAsset);

                // Organization purpose
                workingUI.transform.SetParent(workingUIParent.transform);
            }

            // Organization purpose:
            // Group players into one single game object.
            // Less clutter in the inspector.
            // workingPlayer.transform.SetParent(playerParent.transform);
            // workingUIParent.transform.SetParent(uiParent.transform);
        }

        private void Start()
        {
            NewStart();
            return;
            GameObject playerParent = new GameObject("Players"); // For organization purpose
            GameObject uiParent = new GameObject("UIs"); // For organization purpose
            
            List<Camera> cameraList = CameraHelperClass.GetNewCameras(numOfPlayers);
            
            for (int i = 0; i < numOfPlayers; i++)
            {
                // Creates a new player
                GameObject workingPlayer = Instantiate(playerPrefab);
                Camera workingCamera = cameraList[i];
                
                // Sets players to their location
                SpawnLocation(workingPlayer, i);
                
                // Creating data for each player. (Have their own data)
                // Preparing to set up dependencies.
                PlayerAsset _playerAsset = Instantiate(playerAsset);
                _playerAsset.DeepCopy(playerAsset);
                
                // Sets up dependencies
                IInitPlayerAsset playerInitializer = workingPlayer.GetComponent<IInitPlayerAsset>();
                // IInitCameraAsset cameraInitializer = workingPlayer.GetComponent<IInitCameraAsset>(); // Backup in case multiplayer implementation fails.
                IInitController controllerInitializer = workingPlayer.GetComponent<IInitController>();
                playerInitializer.InitPlayer(_playerAsset);
                // cameraInitializer.InitCamera(workingCamera); // Backup in case multiplayer implementation fails
                controllerInitializer.InitController();
                
                // Sets up UI and dependencies
                Canvas workingUI;
                GameObject workingUIParent = new GameObject(String.Format("UI_Player_{0}", i));
                foreach (Canvas ui in uiPrefabs)
                {
                    // Sets up UI so that it isn't too far(default)
                    workingUI = Instantiate(ui);
                    workingUI.renderMode = RenderMode.ScreenSpaceCamera;
                    workingUI.planeDistance = 1;
                    workingUI.worldCamera = workingCamera;

                    // Sets up dependencies
                    // UI isn't part of the player prefab so we must also initialize it separately.
                    playerInitializer = workingUI.GetComponent<IInitPlayerAsset>();
                    if(playerInitializer != null)
                        playerInitializer.InitPlayer(_playerAsset);

                    // Organization purpose
                    workingUI.transform.SetParent(workingUIParent.transform);
                }

                // Organization purpose:
                // Group players into one single game object.
                // Less clutter in the inspector.
                workingPlayer.transform.SetParent(playerParent.transform);
                workingUIParent.transform.SetParent(uiParent.transform);
            }
        }

        protected virtual void SpawnLocation(GameObject player, int playerNum)
        {
            player.transform.position = Vector3.right * playerNum * 3 + Vector3.up;
        }
    }
}
