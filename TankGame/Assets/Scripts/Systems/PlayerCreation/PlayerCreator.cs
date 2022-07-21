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

namespace Systems.PlayerCreation
{
    public class PlayerCreator : MonoBehaviour
    {
        [SerializeField] private int numOfPlayers;
        [SerializeField] private GameObject playerPrefab;

        [Header("Player Initial State")]
        [SerializeField] private PlayerAsset playerAsset;
        
        [Header("UI")]
        [SerializeField] private List<Canvas> uiPrefabs;

        private void Start()
        {
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
                IInitCameraAsset cameraInitializer = workingPlayer.GetComponent<IInitCameraAsset>();
                playerInitializer.InitPlayer(_playerAsset);
                cameraInitializer.InitCamera(workingCamera);
                
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
