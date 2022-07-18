using System;
using System.Runtime.CompilerServices;
using Gameplay.Camera.Interfaces;
using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Camera
{
    /**
     * Obsolete: It is much easier and likely better performance if we attach the camera to the player instead.
     */
    [Obsolete]
    public class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] private GameObject objectToStare;
        [SerializeField] private float distance;
        [SerializeField] private float angleFromZPlane;

        [Header("Debug")]
        [SerializeField] private bool objHasDifferentLocation; // If the stare obj implements IobjTransform or other.
        private IObjTransform objLocation;
        
        [SerializeField] private Vector3 relativeLocation;
        [SerializeField] private Vector3 objLoc;

        private void Start()
        {
            Init();
            objLocation = objectToStare.GetComponent<IObjTransform>();
            objHasDifferentLocation = objLocation != null;
            
            // Sets the camera's initial position
            UpdateCameraPosition();
        }

        private void Init()
        {
            relativeLocation = Vector3.back * Mathf.Cos(angleFromZPlane * Mathf.Deg2Rad);
            relativeLocation += Vector3.up * Mathf.Sin(angleFromZPlane * Mathf.Deg2Rad);
            relativeLocation *= distance;
        }

        private void LateUpdate()
        {
            UpdateRelativeLocation();
            UpdateObjLoc();
            UpdateCameraPosition();
            
            UpdateCamRotation();
        }

        /**
         * Try to look at the objectToStare in the direction that it is looking
         * This method deals with calculating where to place the current object relative to objectToStare.
         */
        private void UpdateRelativeLocation()
        {
            if (objHasDifferentLocation)
            {
                Transform objTransform = objLocation.GetTransform(); // Get the most recent location
                relativeLocation = objTransform.forward * Mathf.Cos((angleFromZPlane + 180) * Mathf.Deg2Rad);
                relativeLocation += Vector3.up * Mathf.Sin(angleFromZPlane * Mathf.Deg2Rad);
                relativeLocation *= distance;
            }
        }

        /**
         * Sets the camera location
         */
        private void UpdateCameraPosition()
        {
            transform.position = objLoc + relativeLocation;
        }

        /**
         * Gets the most recent objectToStare location
         */
        private void UpdateObjLoc()
        {
            if (objHasDifferentLocation)
            {
                objLoc = objLocation.GetPosition();
                return;
            }
            objLoc = objectToStare.transform.position;
        }

        /**
         * Sets the Camera rotation to look at the objectToStare
         */
        private void UpdateCamRotation()
        {
            transform.rotation = Quaternion.LookRotation(objLoc - transform.position);
        }
    }
}