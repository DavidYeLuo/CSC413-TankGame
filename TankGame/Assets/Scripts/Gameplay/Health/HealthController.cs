using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Health
{
    public class HealthController : Health
    {
        private HealthDriver driver;
        
        public void Init(HealthDriver driver)
        { 
            this.driver = driver;
        }

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