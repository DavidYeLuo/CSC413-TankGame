using System;
using System.Collections.Generic;
using Gameplay.Movement;
using ScriptableObjects;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Gameplay.Health
{
    public class HealthDriver : MonoBehaviour, IRequirePlayerAsset
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

        public void SetHealth(IntReference asset)
        {
            healthAsset = asset;
        }

        public void SetMaxHealth(IntReference asset)
        {
            maxHealthAsset = asset;
        }

        protected void SetHealth(int hp)
        {
            _health = Validate(hp);
        }

        protected int GetHealth()
        {
            return _health;
        }

        protected int GetMaxHealth()
        {
            return _maxHealth;
        }

        protected void SetMaxHealth(int hp)
        {
            _maxHealth = hp;
        }

        private void AddHealth(int hp)
        {
            _health += Validate(hp);
        }
        
        private void LoseHealth(int hp)
        {
            _health -= Validate(hp);
        }

        private int Validate(int value)
        {
            return Math.Clamp(value, 0, maxHealth);
        }

        public virtual void TakeDamage(int health)
        {
            LoseHealth(health);
        }

        public virtual void Heal(int health)
        {
            AddHealth(health);
        }

        public void GetPlayerAsset(PlayerAsset asset)
        {
            useAssets = true;
            healthAsset = asset.GetHealthAsset();
            maxHealthAsset = asset.GetMaxHealthAsset();
        }
    }
}