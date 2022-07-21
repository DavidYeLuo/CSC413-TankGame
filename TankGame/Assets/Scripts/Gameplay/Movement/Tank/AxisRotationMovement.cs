using Systems.InputSystem;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Movement.Tank
{
    public class AxisRotationMovement : LookDriver
    {
        [Header("Developer Settings")]
        [SerializeField] private bool lockHorizontalRot;
        [SerializeField] private bool lockVerticalRot;
        [SerializeField] private GameObject turret;
        [SerializeField] private Rigidbody rb;

        private Vector3 lookRotation;

        public override void Look(Vector2 direction)
        {
            lookRotation = Vector3.zero;
            if(!lockHorizontalRot)
                lookRotation += Vector3.up * direction.x * horizontalSensitivity;
            if (!lockVerticalRot)
                lookRotation += turret.transform.right * direction.y * -1 * verticalSensitivity;
            if (lookRotation == Vector3.zero) return;
            rb.AddTorque(lookRotation * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
