using Gameplay.Health.Interfaces;
using UnityEngine;

namespace Gameplay.Collision
{
    public class DamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private AudioSource audio;

        private void OnTriggerEnter(Collider collider)
        {
            if(audio != null)
                audio.Play();
            
            ITakeDamage obj = collider.gameObject.GetComponent<ITakeDamage>();
            if (obj == null) return;
            obj.TakeDamage(damage);
        }
    }
}