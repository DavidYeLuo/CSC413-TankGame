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
    public class PlayerCreator : MonoBehaviour
    {
        [Header("Player Initial State")]
        [SerializeField] private PlayerAsset playerAsset;
        private Vector3 spawnPosition;
        private Quaternion spawnRotation;
        
        [Header("UI")]
        [SerializeField] private List<Canvas> uiPrefabs;
        
        // For organizing
        private GameObject playerParent;
        private GameObject playerUIParent;

        public GameObject Init(GameObject playerPrefab, PlayerInput playerInput)
        {
            // Creates a new player
            GameObject workingPlayer = Instantiate(playerPrefab);
            Camera workingCamera = playerInput.camera;
            PlayerAsset _playerAsset = DeepCopyAsset(playerAsset);
            
            InitializePlayer(workingPlayer, _playerAsset, playerInput);
            InitializeUI(_playerAsset, workingCamera);
            AttachCameraToPlayer(workingPlayer, workingCamera);
            SpawnPlayerAt(workingPlayer, spawnPosition);
            SpawnPlayerWithOrientation(workingPlayer, spawnRotation);

            // Organization purpose
            if (playerParent == null) playerParent = new GameObject("Players");
            workingPlayer.transform.SetParent(playerParent.transform);
            return workingPlayer;
        }
        private PlayerAsset DeepCopyAsset(PlayerAsset asset)
        {
            PlayerAsset _playerAsset = Instantiate(playerAsset);
            _playerAsset.DeepCopy(playerAsset);
            return _playerAsset;
        }

        private void InitializePlayer(GameObject player, PlayerAsset asset, PlayerInput playerInput)
        {
            IInitPlayerAsset playerInitializer = player.GetComponent<IInitPlayerAsset>();
            playerInitializer.InitPlayer(asset);
            IInitController controllerInitializer = player.GetComponent<IInitController>();
            controllerInitializer.InitController(playerInput);
        }

        /**
         * Legacy: Just in case we need it in the future.
         * Reason that we don't need it anymore:
         * Unity's PlayerInput class already provide us a camera.
         */
        private void AttachCameraToPlayer(GameObject player, Camera cam)
        {
            IInitCameraAsset cameraInitializer = player.GetComponent<IInitCameraAsset>(); 
            cameraInitializer.InitCamera(cam);
        }

        private void InitializeUI(PlayerAsset asset, Camera workingCamera)
        {
            GameObject workingUIParent = new GameObject(String.Format("UI_Player")); // Organization purpose
            
            Canvas workingUI;
            IInitPlayerAsset playerInitializer;
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
                    playerInitializer.InitPlayer(asset);
                
                // Organization purpose
                workingUI.transform.SetParent(workingUIParent.transform);
            }

            // Organization purpose
            if (playerUIParent == null) playerUIParent = new GameObject("PlayersUI");
            workingUIParent.transform.SetParent(playerUIParent.transform);
        }

        private void SpawnPlayerAt(GameObject player, Vector3 position)
        {
            player.transform.position = position;
        }

        private void SpawnPlayerWithOrientation(GameObject player, Quaternion rotation)
        {
            player.transform.rotation = rotation;
        }

        public void SetSpawnPosition(Vector3 position)
        {
            spawnPosition = position;
        }

        public void SetSpawnRotation(Quaternion rotation)
        {
            spawnRotation = rotation;
        }
        
        // Legacy Code
        //
        // private void Start()
        // {
        //     GameObject playerParent = new GameObject("Players"); // For organization purpose
        //     GameObject uiParent = new GameObject("UIs"); // For organization purpose
        //     
        //     List<Camera> cameraList = CameraHelperClass.GetNewCameras(numOfPlayers);
        //     
        //     for (int i = 0; i < numOfPlayers; i++)
        //     {
        //         // Creates a new player
        //         GameObject workingPlayer = Instantiate(playerPrefab);
        //         Camera workingCamera = cameraList[i];
        //         
        //         // Sets players to their location
        //         SpawnLocation(workingPlayer, i);
        //         
        //         // Creating data for each player. (Have their own data)
        //         // Preparing to set up dependencies.
        //         PlayerAsset _playerAsset = Instantiate(playerAsset);
        //         _playerAsset.DeepCopy(playerAsset);
        //         
        //         // Sets up dependencies
        //         IInitPlayerAsset playerInitializer = workingPlayer.GetComponent<IInitPlayerAsset>();
        //         // IInitCameraAsset cameraInitializer = workingPlayer.GetComponent<IInitCameraAsset>(); // Backup in case multiplayer implementation fails.
        //         IInitController controllerInitializer = workingPlayer.GetComponent<IInitController>();
        //         playerInitializer.InitPlayer(_playerAsset);
        //         // cameraInitializer.InitCamera(workingCamera); // Backup in case multiplayer implementation fails
        //         controllerInitializer.InitController();
        //         
        //         // Sets up UI and dependencies
        //         Canvas workingUI;
        //         GameObject workingUIParent = new GameObject(String.Format("UI_Player_{0}", i));
        //         foreach (Canvas ui in uiPrefabs)
        //         {
        //             // Sets up UI so that it isn't too far(default)
        //             workingUI = Instantiate(ui);
        //             workingUI.renderMode = RenderMode.ScreenSpaceCamera;
        //             workingUI.planeDistance = 1;
        //             workingUI.worldCamera = workingCamera;
        //
        //             // Sets up dependencies
        //             // UI isn't part of the player prefab so we must also initialize it separately.
        //             playerInitializer = workingUI.GetComponent<IInitPlayerAsset>();
        //             if(playerInitializer != null)
        //                 playerInitializer.InitPlayer(_playerAsset);
        //
        //             // Organization purpose
        //             workingUI.transform.SetParent(workingUIParent.transform);
        //         }
        //
        //         // Organization purpose:
        //         // Group players into one single game object.
        //         // Less clutter in the inspector.
        //         workingPlayer.transform.SetParent(playerParent.transform);
        //         workingUIParent.transform.SetParent(uiParent.transform);
        //     }
        // }
    }
}
