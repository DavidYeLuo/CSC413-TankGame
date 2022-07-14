using System;
using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Shooter
{
    public class ShootObject : MonoBehaviour
    {
        [SerializeField] private GameObject objectToShoot;
        [SerializeField] private GameObject shootFrom;
        
        [Header("Recoil")]
        [Tooltip("Must have a RigidBody component for this to work")]
        [SerializeField] private bool hasRecoil;
        [SerializeField] private float recoilForce;

        private InputAction shootControl;
        private Rigidbody rb;

        private void Start()
        {
            shootControl = InputDriver.GetControls().Gameplay.Fire;
            shootControl.performed += shoot;
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            if (shootControl == null) return; // Needed because this is called before Start() also.
            shootControl.performed += shoot;
        }

        private void OnDisable()
        {
            shootControl.performed -= shoot;
        }

        public void shoot(InputAction.CallbackContext callback)
        {
            if (hasRecoil)
            {
                rb.AddForce(recoilForce * (-1) * transform.forward, ForceMode.Force);
            }
            GameObject.Instantiate(objectToShoot, shootFrom.transform.position, transform.rotation);
        }
    }
}
