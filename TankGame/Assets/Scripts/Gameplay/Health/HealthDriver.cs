using System;
using ScriptableObjects;
using UnityEngine;

namespace Gameplay.Health
{
    public class HealthDriver : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        [Header("Assets")]
        [SerializeField] private bool useAssets;
        [SerializeField] private IntReference healthAsset;
        [SerializeField] private IntReference maxHealthAsset;

        // Ugly setter and getter but necessary for development
        private int _health
        {
            get
            {
                if (useAssets) {return healthAsset.GetValue();}
                return health;
            }
            set
            {
                if(useAssets) healthAsset.SetValue(value);
                health = value;
            }
        }
        private int _maxHealth
        {
            get
            {
                if (useAssets) return maxHealthAsset.GetValue();
                return maxHealth;
            }
            set
            {
                if(useAssets) maxHealthAsset.SetValue(value);
                maxHealth = value;
            }
        }

        public void SetHealth(int hp)
        {
            _health = Validate(hp);
        }

        public void AddHealth(int hp)
        {
            _health += Validate(hp);
        }

        public void LoseHealth(int hp)
        {
            _health -= Validate(hp);
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