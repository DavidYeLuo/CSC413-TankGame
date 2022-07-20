using System;
using System.Collections.Generic;
using Gameplay.Camera;
using Systems.CameraSystem;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Systems.PlayerCreation
{
    public class PlayerCreationDriver : MonoBehaviour
    {
        public virtual void Init(PlayerAsset asset)
        {
            if (asset == null)
            {
                throw new Exception("CreationController: Player asset is empty");
            }
            
            List<IRequirePlayerAsset> deviceControllers = GetListOfReqInterfaces();

            if (deviceControllers == null)
            {
                throw new Exception(String.Format("Player Asset: {0}, device controllers: {1}", asset != null,
                    deviceControllers != null));
            }
            
            foreach (var deviceController in deviceControllers)
            {
                deviceController.GetPlayerAsset(asset);
            }
        }

        public void Init(Camera cam)
        {
            if (cam == null)
            {
                throw new Exception("CreationController: Camera is null");
            }

            CameraLocation camLocation = GetCameraLocation();
            if (camLocation == null) return;
            CameraHelperClass.AttachCamera(cam, camLocation);
        }

        private CameraLocation GetCameraLocation()
        {
            return GetComponentInChildren<CameraLocation>();
        }
        private List<IRequirePlayerAsset> GetListOfReqInterfaces()
        {
            return new List<IRequirePlayerAsset>(gameObject.GetComponentsInChildren<IRequirePlayerAsset>());
        }
    }
}