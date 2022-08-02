using System;
using Gameplay.Shooter.Interfaces;
using Systems.InputSystem;
using Systems.PlayerCreation.Helpers;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Shooter
{
    public class ShootController : MonoBehaviour, IRequireController, IShootable, IAddSpecialAmmunition
    {
        [Header("Control")] 
        [Tooltip("Action button for shooting. NOTE: Spelling matters.")]
        [SerializeField] private string nameOfFireAction;

        [SerializeField] private ShootDriver driver;

        private InputAction fireControl;

        private void Start()
        {
            if(fireControl == null)
                fireControl = InputDriver.GetControls().Gameplay.Fire;
            SubscribeToFireEvent();
        }

        private void SubscribeToFireEvent()
        {
            fireControl.performed += OnShoot;
        }

        private void UnsubscribeToFireEvent()
        {
            fireControl.performed -= OnShoot;
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

        private void OnShoot(InputAction.CallbackContext callback)
        {
            driver.Shoot();
        }

        public void GetController(InputActionMap map)
        {
            if(fireControl != null)
                UnsubscribeToFireEvent();
            fireControl = InputActionHelper.GetInputAction(map, nameOfFireAction);
            SubscribeToFireEvent();
        }

        public void Shoot()
        {
            driver.Shoot();
        }

        public void AddSpecialAmmunition(GameObject prefab, int bullets)
        {
            driver.AddSpecialAmmunition(prefab, bullets);
        }
    }
}
