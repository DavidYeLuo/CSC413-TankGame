using System;
using System.Collections.Generic;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Systems.PlayerCreation
{
    [RequireComponent(typeof(PlayerCreationDriver))]
    public class CreationController : MonoBehaviour, IInitPlayerAsset
    {
        private PlayerCreationDriver driver;
        [SerializeField] private PlayerAsset playerAsset;
        [SerializeField] private Camera camera;

        // We use Awake because InitPlayer can be called before Start()
        private void Start()
        {
            Init(playerAsset);
            InitCamera(camera);
        }

        private void Init(PlayerAsset asset)
        {
            if(driver == null)
                driver = GetComponent<PlayerCreationDriver>();
            driver.Init(asset);
        }

        private void Init(Camera cam)
        {
            if(driver == null)
                driver = GetComponent<PlayerCreationDriver>();
            if (cam == null) return; // Not all players have camera
            driver.Init(cam);
        }

        public void InitPlayer(PlayerAsset asset)
        {
            playerAsset = asset;
            Init(playerAsset);
        }

        public void InitCamera(Camera cam)
        {
            camera = cam;
            Init(camera);
        }
    }
}
