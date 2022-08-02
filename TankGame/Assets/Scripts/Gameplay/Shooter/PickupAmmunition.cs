using Gameplay.Shooter.Interfaces;
using UnityEngine;

namespace Gameplay.Shooter
{
    public class PickupAmmunition : MonoBehaviour, IAddSpecialAmmunition
    {
        [SerializeField] private ShootController controller;
        public void AddSpecialAmmunition(GameObject prefab, int bullets)
        {
            controller.AddSpecialAmmunition(prefab, bullets);
        }
    }
}