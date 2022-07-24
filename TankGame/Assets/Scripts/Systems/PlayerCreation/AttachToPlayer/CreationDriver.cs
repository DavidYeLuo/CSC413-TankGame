using System;
using System.Collections.Generic;
using Gameplay.Camera;
using Systems.CameraSystem;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.PlayerCreation.AttachToPlayer
{
    public class CreationDriver : MonoBehaviour
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
        public void Init(InputActionMap map)
        {
            if (map == null)
            {
                throw new Exception("InputCreationController: Player asset is empty");
            }
            
            List<IRequireController> deviceControllers = GetListOfReqControllers();

            if (deviceControllers == null)
            {
                throw new Exception(String.Format("Player Asset: {0}, device controllers: {1}", map != null,
                    deviceControllers != null));
            }
            
            foreach (var deviceController in deviceControllers)
            {
                deviceController.GetController(map);
            }
        }

        private CameraLocation GetCameraLocation()
        {
            return GetComponentInChildren<CameraLocation>();
        }
        private List<IRequirePlayerAsset> GetListOfReqInterfaces()
        {
            return new List<IRequirePlayerAsset>(gameObject.GetComponentsInChildren<IRequirePlayerAsset>());
        }
        private List<IRequireController> GetListOfReqControllers()
        {
            return new List<IRequireController>(GetComponentsInChildren<IRequireController>());
        }
    }
}