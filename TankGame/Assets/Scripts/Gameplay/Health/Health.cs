using UnityEngine;

namespace Gameplay.Health
{
    public abstract class Health: MonoBehaviour, IHeal, ITakeDamage
    {
        public abstract void Heal(int health);
        public abstract void TakeDamage(int health);
    }
}