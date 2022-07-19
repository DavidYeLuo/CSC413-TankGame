using System;
using System.Collections.Generic;
using Gameplay.Camera;
using UnityEngine;

// TODO: This is currently a temporary solution to adding a camera to a game object.
// We still need to figure out how we are going to deal with multiple player.
namespace Systems.CameraSystem
{
    public class PlayerCreator : MonoBehaviour
    {
        [SerializeField] private int numOfPlayers;
        [SerializeField] private GameObject playerPrefab;
        
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
                
                // Sets up UI
                Canvas workingUI;
                GameObject workingUIParent = new GameObject(String.Format("UI_Player_{0}", i));
                foreach (Canvas ui in uiPrefabs)
                {
                    workingUI = Instantiate(ui);
                    workingUI.renderMode = RenderMode.ScreenSpaceCamera;
                    workingUI.planeDistance = 1;
                    workingUI.worldCamera = workingCamera;
                    
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
            player.transform.position = Vector3.right * playerNum + Vector3.up;
        }
    }
}
