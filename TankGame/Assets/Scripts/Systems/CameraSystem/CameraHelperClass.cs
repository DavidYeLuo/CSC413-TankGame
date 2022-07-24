using System;
using System.Collections.Generic;
using Gameplay.Camera;
using UnityEngine;

namespace Systems.CameraSystem
{
    public static class CameraHelperClass
    {
        public static List<Camera> GetNewCameras(int numberOfPlayers)
        {
            List<Camera> list = new List<Camera>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Camera workingCamera = _GetNewCamera();
                _InitViewport(workingCamera, numberOfPlayers, i);
                
                list.Add(workingCamera);
            }
            return list;
        }

        public static void AttachCamera(Camera from, CameraLocation to)
        {
            // Developer warning
            if(to.GetComponent<CameraLocation>() == null) 
                Debug.Log("CamInstantiator: camera location isn't a type CameraLocation");
        
            // Sets the camera's transform to be the same as the location's transform.
            from.transform.position = to.transform.position;
            from.transform.rotation = to.transform.rotation;
        
            // Attach the camera to the cameraLocation gameObject
            from.transform.SetParent(to.transform);
        }

        /**
         * Creates and return a new camera.
         */
        private static Camera _GetNewCamera()
        {
            return new GameObject("Camera").AddComponent<Camera>();
        }

        /**
         * Obsolete: Unity has their own way to create split screen.
         */
        private static void _InitViewport(Camera camera, int numOfPlayers, int playerNum)
        {
            float x;
            float y;
            float width;
            float height;
            
            // Ugly implementation but not sure who will have enough friends to make this a problem.
            switch (numOfPlayers)
            {
                case 1:
                    return;
                case 2:
                    width = 1; // Full Width
                    height = 1f / numOfPlayers; // Half height
                    x = 0;
                    y = height * (numOfPlayers - playerNum);
                    break;
                default:
                    throw new Exception("ERROR! There are more camera than we can support!");
            }
            camera.rect = new Rect(x, y, width, height);
        }
    }
}