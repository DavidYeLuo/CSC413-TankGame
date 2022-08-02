using UnityEngine;

namespace Gameplay.Shooter.Interfaces
{
    public interface IAddSpecialAmmunitionResponse
    {
        public void AddSpecialAmmunition(GameObject prefab, int bullets);
    }
}