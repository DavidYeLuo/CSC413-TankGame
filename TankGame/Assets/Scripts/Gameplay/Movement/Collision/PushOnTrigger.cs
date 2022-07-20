using Gameplay.Movement.Interfaces;
using UnityEngine;

namespace Gameplay.Movement.Collision
{
    public class PushOnTrigger : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private bool destroyOnTrigger;

        private void OnTriggerEnter(Collider collider)
        {
            IPushable obj = collider.gameObject.GetComponent<IPushable>();
            if (obj == null) return;
            obj.AddForce(transform.forward * force);
            
            if(destroyOnTrigger) gameObject.SetActive(false);
        }
    }
}