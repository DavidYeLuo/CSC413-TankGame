using UnityEngine;

namespace Gameplay.Rotation.Tank
{
    public class TankTurretAndBarrelRotationDriver : LookDriver
    {
        [Header("TankComponents")]
        [SerializeField] private GameObject turret;
        [SerializeField] private GameObject barrel;
        [SerializeField] private Rigidbody turretRigidBody;
        [SerializeField] private Rigidbody barrelRigidbody;

        private Vector3 horizontalLookRotation;
        private Vector3 verticalLookRotation;

        public override void Look(Vector2 direction)
        {
            if (direction == Vector2.zero) return;
            
            horizontalLookRotation = Vector3.zero;
            verticalLookRotation = Vector3.zero;
            horizontalLookRotation += Vector3.up * direction.x * horizontalSensitivity.GetValue();
            verticalLookRotation += turret.transform.right * direction.y * -1 * verticalSensitivity.GetValue();

            turretRigidBody.AddTorque(horizontalLookRotation * Time.deltaTime, ForceMode.Impulse);
            barrelRigidbody.AddTorque(verticalLookRotation * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
