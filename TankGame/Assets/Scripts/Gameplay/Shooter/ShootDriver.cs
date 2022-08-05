using Gameplay.Shooter.Interfaces;
using UnityEngine;

namespace Gameplay.Shooter
{
    public class ShootDriver : MonoBehaviour, IShootResponse
    {
        [SerializeField] private GameObject objectToShoot;
        [SerializeField] private GameObject shootFrom;
        
        [Header("Recoil")]
        [Tooltip("Must have a RigidBody component for this to work")]
        [SerializeField] private bool hasRecoil;
        [SerializeField] private float recoilForce;
        [SerializeField] private GameObject specialAmmunition;
        [SerializeField] private int specialAmmunitionCount;
        [SerializeField] private Rigidbody forceToApplyTo;
        [SerializeField] private AudioSource audioSource;
        
        public void Shoot()
        {
            if (hasRecoil)
            {
                forceToApplyTo.AddForce(recoilForce * (-1) * shootFrom.transform.forward, ForceMode.Force);
            }

            if (audioSource != null)
            {
                audioSource.Play(0);
            }

            if (specialAmmunitionCount > 0)
            {
                Instantiate(specialAmmunition, shootFrom.transform.position, shootFrom.transform.rotation);
                specialAmmunitionCount--;
                return;
            }
            
            Instantiate(objectToShoot, shootFrom.transform.position, shootFrom.transform.rotation);
        }

        public void AddSpecialAmmunition(GameObject prefab, int bullets)
        {
            specialAmmunition = prefab;
            specialAmmunitionCount = bullets;
        }
    }
}