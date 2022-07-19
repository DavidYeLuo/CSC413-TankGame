using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Health
{
    public class DisplayHealth : MonoBehaviour
    {
        private Image image;
        [SerializeField] private IntReference health;
        [SerializeField] private IntReference maxHealth;

        public void SetHealth(IntReference asset)
        {
            if (health != null) health.valueChangeEvent -= OnHealthChange;
            health = asset;
            health.valueChangeEvent += OnHealthChange;
        }

        public void SetMaxHealth(IntReference asset)
        {
            if (maxHealth != null) maxHealth.valueChangeEvent -= OnHealthChange;
            maxHealth = asset;
            maxHealth.valueChangeEvent += OnHealthChange;
        }

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