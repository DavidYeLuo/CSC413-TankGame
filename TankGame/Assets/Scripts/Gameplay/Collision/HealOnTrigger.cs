using Gameplay.Health.Interfaces;
using UnityEngine;

namespace Gameplay.Collision
{
    public class HealOnTrigger : MonoBehaviour
    {
        [SerializeField] private int value;
        [SerializeField] private AudioSource audio;

        private void OnTriggerEnter(Collider collider)
        {
            if(audio != null)
                audio.Play();
        
            IHeal obj = collider.gameObject.GetComponent<IHeal>();
            if (obj == null) return;
            obj.Heal(value);
        }
    }
}
