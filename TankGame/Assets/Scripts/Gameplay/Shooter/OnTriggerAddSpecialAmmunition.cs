using Gameplay.Shooter.Interfaces;
using UnityEngine;

namespace Gameplay.Shooter
{
    public class OnTriggerAddSpecialAmmunition : MonoBehaviour
    {
        [SerializeField] private GameObject specialBulletPrefab;
        [SerializeField] private int ammoCount;
        [SerializeField] private AudioSource audio;

        private void OnTriggerEnter(Collider collider)
        {
            if(audio != null)
                audio.Play();
            
            IAddSpecialAmmunition obj = collider.gameObject.GetComponent<IAddSpecialAmmunition>();
            if (obj == null) return;
            obj.AddSpecialAmmunition(specialBulletPrefab, ammoCount);
        }
    }
}