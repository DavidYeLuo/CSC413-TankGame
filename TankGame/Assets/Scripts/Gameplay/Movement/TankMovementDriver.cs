using System;
using ScriptableObjects;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

namespace Gameplay.Movement
{
    public class TankMovementDriver : MovementDriver
    {
        [SerializeField] private float maxSteerDeg;
        
        [SerializeField] private WheelCollider bLeftWheel;
        [SerializeField] private WheelCollider fLeftWheel;
        [SerializeField] private WheelCollider bRightWheel;
        [SerializeField] private WheelCollider fRightWheel;
        
        [Header("Debug")] 
        [SerializeField] private float torque;
        [SerializeField] private float steeringAngle;
        
        // Cache for Move(direction)
        private Vector2 dir;
        private float wheelRadius; // Assuming each wheel is the same size
        
        // Start is called before the first frame update
        void Start()
        {
            wheelRadius = bLeftWheel.radius;
        }

        /**
         * New Movement
         */
        public override void Move(Vector2 direction)
        {
            dir = direction;
            HandleMotor();
            SteerWheels();
        }

        private void HandleMotor()
        {
            torque = dir.y * pushForceAsset.GetValue() * wheelRadius;
            
            // Back wheels
            bLeftWheel.motorTorque = torque;
            bRightWheel.motorTorque = torque;

            // Steering
            fLeftWheel.motorTorque = torque;
            fRightWheel.motorTorque = torque;
        }

        private void SteerWheels()
        {
            steeringAngle = Math.Min(dir.x * Mathf.Rad2Deg, maxSteerDeg);
            
            fLeftWheel.steerAngle = steeringAngle;
            fRightWheel.steerAngle = steeringAngle;
        }
    }
}
