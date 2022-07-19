using System;
using System.Collections.Generic;
using Gameplay.Camera;
using Gameplay.Health;
using Gameplay.Movement;
using ScriptableObjects;
using Systems.CameraSystem;
using UI.Health;
using UnityEngine;

// TODO: This is currently a temporary solution to adding a camera to a game object.
// We still need to figure out how we are going to deal with multiple player.
namespace Systems.PlayerCreation
{
    public class PlayerCreator : MonoBehaviour
    {
        [SerializeField] private int numOfPlayers;
        [SerializeField] private GameObject playerPrefab;

        [Header("Player Initial State")]
        [SerializeField] private PlayerAsset playerAsset;
        [SerializeField] private FloatReference movementForce; // aka pushForce or movement impulse

        [SerializeField] private IntReference health;
        [SerializeField] private IntReference maxHealth;
        
        [Header("UI")]
        [SerializeField] private List<Canvas> uiPrefabs;

        private void Start()
        {
            GameObject playerParent = new GameObject("Players"); // For organization purpose
            GameObject uiParent = new GameObject("UIs");
            
            List<Camera> cameraList = CameraHelperClass.GetNewCameras(numOfPlayers);
            
            for (int i = 0; i < numOfPlayers; i++)
            {
                // Creates a new player
                GameObject workingPlayer = Instantiate(playerPrefab);
                
                // Sets players to their location
                SpawnLocation(workingPlayer, i);
                
                // Attaching Camera
                CameraLocation cameraLocation = workingPlayer.GetComponentInChildren<CameraLocation>();
                Camera workingCamera = cameraList[i];
                CameraHelperClass.AttachCamera(workingCamera, cameraLocation);
                
                // New Way
                PlayerAsset _playerAsset = Instantiate(playerAsset);
                _playerAsset.DeepCopy(playerAsset);
                
                CreationController creationController = workingPlayer.GetComponent<CreationController>();
                creationController.Init(_playerAsset);
                
                // Sets up UI
                Canvas workingUI;
                GameObject workingUIParent = new GameObject(String.Format("UI_Player_{0}", i));
                foreach (Canvas ui in uiPrefabs)
                {
                    workingUI = Instantiate(ui);
                    workingUI.renderMode = RenderMode.ScreenSpaceCamera;
                    workingUI.planeDistance = 1;
                    workingUI.worldCamera = workingCamera;
                    
                    // Organization purpose
                    workingUI.transform.SetParent(workingUIParent.transform);
                }
                
                // Sets up UI dependencies
                DisplayHealth displayHealth = workingUIParent.GetComponentInChildren<DisplayHealth>();
                // displayHealth.SetHealth(_health); // TODO: Delete this after done
                // displayHealth.SetMaxHealth(_maxHealth); // TODO: Delete this after done

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
