using System;
using UnityEngine;

namespace Gameplay.Health
{
    public class HealthDriver : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        public void SetHealth(int hp)
        {
            health = Validate(hp);
        }

        public void AddHealth(int hp)
        {
            health += Validate(hp);
        }

        public void SubtractHealth(int hp)
        {
            health -= Validate(hp);
        }

        public int GetHealth()
        {
            return health;
        }

        private int Validate(int value)
        {
            return Math.Clamp(value, 0, maxHealth);
        }
    }
}