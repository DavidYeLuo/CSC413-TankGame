using ScriptableObjects;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Gameplay.Movement
{
    public class MovementDriver : Movement, IRequirePlayerAsset
    {
        [SerializeField] protected FloatReference pushForceAsset;
        
        public override void Move(Vector2 direction)
        {
            throw new System.NotImplementedException();
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
        public void GetPlayerAsset(PlayerAsset asset)
        {
            pushForceAsset = asset.GetPushForceAsset();
        }
    }
}