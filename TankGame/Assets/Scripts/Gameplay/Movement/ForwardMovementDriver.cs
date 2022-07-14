using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Gameplay.Movement
{
    /**
     * This class doesn't require a MovementController to function.
     */
    [RequireComponent(typeof(Rigidbody))]
    public class ForwardMovementDriver : MovementDriver
    {
        private Rigidbody rb;
        [SerializeField] private float force;

        [Header("Debug")] 
        [SerializeField] private Vector3 direction;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            direction = transform.forward;
            rb.AddForce(force * Time.deltaTime * direction, ForceMode.Impulse);
        }
        
        public override void Move(Vector2 direction)
        {
            Debug.Log("Move method in ForwardMovementDriver.cs shouldn't be used.");
        }
    }
}