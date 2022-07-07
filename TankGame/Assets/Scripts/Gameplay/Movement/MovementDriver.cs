using UI;
using UnityEngine;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementDriver : MonoBehaviour
    {
        [SerializeField] private FloatReference forceMagnitude;
        [SerializeField] private FloatReference maxVelocity;

        [Header("Debug")] 
        [SerializeField] private Vector2 inputDirection;
        [SerializeField] private Vector3 force;
        [SerializeField] private Vector3 velocity;
    
        private Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        public void Move(Vector2 direction)
        {
            inputDirection = direction; // Used to display on inspector
            velocity = rb.velocity;
        
            if (velocity.magnitude > maxVelocity.GetValue()) return;
            force = transform.forward * direction.y + transform.right * direction.x;
            force *= forceMagnitude.GetValue();
            rb.AddForce(force * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
