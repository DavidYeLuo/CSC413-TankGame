using ScriptableObjects;
using Systems.PlayerCreation.Interfaces;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Health
{
    public class DisplayHealth : MonoBehaviour, IRequirePlayerAsset
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
            Subscribe();
        }
        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            health.valueChangeEvent += OnHealthChange;
            maxHealth.valueChangeEvent += OnHealthChange;
        }

        private void Unsubscribe()
        {
            health.valueChangeEvent -= OnHealthChange;
            maxHealth.valueChangeEvent -= OnHealthChange;
        }

        private void OnHealthChange()
        {
            image.fillAmount = (float) health.GetValue() / maxHealth.GetValue();
        }

        public void GetPlayerAsset(PlayerAsset asset)
        {
            if(health == null || maxHealth == null)
                Unsubscribe();
            health = asset.GetHealthAsset();
            maxHealth = asset.GetMaxHealthAsset();
            Subscribe();
        }
    }
}