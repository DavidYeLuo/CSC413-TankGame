using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Health
{
    [RequireComponent(typeof(Collider))]
    public class HealthController : Health
    {
        [SerializeField] private HealthDriver driver;

        public override void Heal(int health)
        {
            driver.Heal(health);
        }

        public override void TakeDamage(int health)
        {
            driver.TakeDamage(health);
        }
    }
}