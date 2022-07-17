using System;
using System.Runtime.CompilerServices;
using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Camera
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] private GameObject objectToStare;
        [SerializeField] private float distance;
        [SerializeField] private float angleFromZPlane;

        [SerializeField] private Vector3 relativeLocation;

        [Header("Debug")] [SerializeField] private bool objHasDifferentLocation;
        private IObjTransform objLocation;

        [SerializeField] private Vector3 objLoc;
        [SerializeField] private Quaternion objRot;

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

        private void FixedUpdate()
        {
            UpdateRelativeLocation();
            UpdateObjLoc();
            UpdateCameraPosition();
            
            // UpdateObjRot();
            UpdateCamRotation();
        }

        private void UpdateRelativeLocation()
        {
            if (objHasDifferentLocation)
            {
                Transform objTransform = objLocation.GetTransform();
                relativeLocation = objTransform.forward * Mathf.Cos((angleFromZPlane + 180) * Mathf.Deg2Rad);
                relativeLocation += Vector3.up * Mathf.Sin(angleFromZPlane * Mathf.Deg2Rad);
                // relativeLocation = relativeLocation.normalized;
                relativeLocation *= distance;
            }
        }

        private void UpdateCameraPosition()
        {
            transform.position = objLoc + relativeLocation;
        }

        private void UpdateObjLoc()
        {
            if (objHasDifferentLocation)
            {
                objLoc = objLocation.GetPosition();
                return;
            }
            objLoc = objectToStare.transform.position;
        }

        private void UpdateCamRotation()
        {
            transform.rotation = Quaternion.LookRotation(objLoc - transform.position);
        }

        /**
         * Didn't intent to not use. Since it's not working as intended, I won't use it.
         */
        private void UpdateObjRot()
        {
            if (objHasDifferentLocation)
            {
                objRot = objLocation.GetRotation();
                return;
            }
            objRot = objectToStare.transform.rotation;
        }
    }
}