using Gameplay.Camera;
using UnityEngine;

// TODO: This is currently a temporary solution to adding a camera to a game object.
// We still need to figure out how we are going to deal with multiple player.
namespace Systems.CameraSystem
{
    public class CamInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject cameraLocation;

        private void Start()
        {
            Camera workingCamera = (CameraHelperClass.GetNewCamera(1))[0];
            
            CameraHelperClass.AttachCamera(workingCamera, cameraLocation);
        }
    }
}
