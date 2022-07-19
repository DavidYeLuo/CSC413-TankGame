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

        private void Start()
        {
            GameObject playerList = new GameObject("Players"); // For organization purpose
            List<Camera> cameraList = CameraHelperClass.GetNewCameras(numOfPlayers);
            
            for (int i = 0; i < numOfPlayers; i++)
            {
                GameObject workingPlayer = Instantiate(playerPrefab);
                SpawnLocation(workingPlayer, i);
                
                CameraLocation cameraLocation = workingPlayer.GetComponentInChildren<CameraLocation>();
                Camera workingCamera = cameraList[i];
                CameraHelperClass.AttachCamera(workingCamera, cameraLocation);
                
                // Organization purpose:
                // Group players into one single game object.
                // Less clutter in the inspector.
                workingPlayer.transform.SetParent(playerList.transform);
            }
        }

        protected virtual void SpawnLocation(GameObject player, int playerNum)
        {
            player.transform.position = Vector3.right * playerNum + Vector3.up;
        }
    }
}
