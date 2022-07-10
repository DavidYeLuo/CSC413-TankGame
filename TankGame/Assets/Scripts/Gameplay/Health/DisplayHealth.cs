using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Health
{
    public class DisplayHealth : MonoBehaviour
    {
        private Image image;
        [SerializeField] private IntReference health;
        [SerializeField] private IntReference maxHealth;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            health.valueChangeEvent += OnHealthChange;
            maxHealth.valueChangeEvent += OnHealthChange;
        }
        private void OnDisable()
        {
            health.valueChangeEvent -= OnHealthChange;
            maxHealth.valueChangeEvent -= OnHealthChange;
        }

        private void OnHealthChange()
        {
            image.fillAmount = (float) health.GetValue() / maxHealth.GetValue();
        }
    }
}