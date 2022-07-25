using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Systems.PlayerCreation.AttachToPlayer
{
    public class CameraCreationController : MonoBehaviour, IInitCameraAsset
    {
        [SerializeField] private Camera camera;
        private CreationDriver driver;

        private void Start()
        {
            InitCamera(camera);
        }
        
        private void Init(Camera cam)
        {
            if(driver == null)
                driver = GetComponent<CreationDriver>();
            if (cam == null) return; // Not all players have camera
            driver.Init(cam);
        }
        
        public void InitCamera(Camera cam)
        {
            camera = cam;
            Init(camera);
        }
    }
}