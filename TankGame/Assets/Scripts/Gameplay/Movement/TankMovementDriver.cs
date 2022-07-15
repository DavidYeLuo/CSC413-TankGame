using System;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

namespace Gameplay.Movement
{
    public class TankMovementDriver : MovementDriver
    {
        [SerializeField] private float pushForce;
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
         * Old Movement
         */
        // public void Move(Vector2 direction)
        // {
        //     inputDirection = direction; // Used to display on inspector
        //     velocity = rb.velocity;
        //
        //     if (velocity.magnitude > maxVelocity.GetValue()) return;
        //     // force = transform.forward * direction.y + transform.right * direction.x;
        //     // force *= forceMagnitude.GetValue();
        //     // rb.AddForce(force * Time.deltaTime, ForceMode.Impulse);
        //
        //     force = Vector3.forward * direction.y + Vector3.right * direction.x;
        //     rb.AddRelativeForce(Time.deltaTime * force * forceMagnitude.GetValue(), ForceMode.Impulse);
        // }
        //
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
            torque = dir.y * pushForce * wheelRadius;
            
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
