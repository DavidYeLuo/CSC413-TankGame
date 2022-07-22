using System;
using Systems.InputSystem;
using Systems.PlayerCreation.Helpers;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Shooter
{
    public class ShootObject : MonoBehaviour, IRequireController
    {
        [SerializeField] private GameObject objectToShoot;
        [SerializeField] private GameObject shootFrom;

        [Header("Control")] 
        [Tooltip("Action button for shooting. NOTE: Spelling matters.")]
        [SerializeField] private string nameOfShootAction;
        
        [Header("Recoil")]
        [Tooltip("Must have a RigidBody component for this to work")]
        [SerializeField] private bool hasRecoil;
        [SerializeField] private float recoilForce;
        [SerializeField] private Rigidbody forceToApplyTo;

        private InputAction fireControl;

        // TODO: Make sure that we properly inject control with this.
        private void Start()
        {
            if(fireControl == null)
                fireControl = InputDriver.GetControls().Gameplay.Fire;
            SubscribeToFireEvent();
        }

        private void SubscribeToFireEvent()
        {
            fireControl.performed += Shoot;
        }

        private void UnsubscribeToFireEvent()
        {
            fireControl.performed -= Shoot;
        }

        private void OnEnable()
        {
            if (fireControl == null) return; // Needed because this is called before Start() also.
            SubscribeToFireEvent();
        }

        private void OnDisable()
        {
            UnsubscribeToFireEvent();
        }

        public void Shoot(InputAction.CallbackContext callback)
        {
            if (hasRecoil)
            {
                forceToApplyTo.AddForce(recoilForce * (-1) * shootFrom.transform.forward, ForceMode.Force);
            }
            Instantiate(objectToShoot, shootFrom.transform.position, shootFrom.transform.rotation);
        }

        public void GetController(InputActionMap map)
        {
            if(fireControl != null)
                UnsubscribeToFireEvent();
            fireControl = InputActionHelper.GetInputAction(map, nameOfShootAction);
            SubscribeToFireEvent();
        }
    }
}
