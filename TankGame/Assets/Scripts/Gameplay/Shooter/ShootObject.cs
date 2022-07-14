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

        private InputAction shootControl;

        private void Start()
        {
            shootControl = InputDriver.GetControls().Gameplay.Fire;
            shootControl.performed += shoot;
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
            GameObject.Instantiate(objectToShoot, shootFrom.transform.position, Quaternion.identity);
        }
    }
}
