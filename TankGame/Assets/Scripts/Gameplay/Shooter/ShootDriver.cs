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
            Instantiate(objectToShoot, shootFrom.transform.position, shootFrom.transform.rotation);
        }
    }
}