using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Health
{
    [RequireComponent(typeof(HealthDriver))]
    public class HealthController : MonoBehaviour
    {
        // private static Dictionary<GameObject, HealthController> map;
        [SerializeField] private static Dictionary<GameObject, HealthController> map;

        private HealthDriver driver;

        private void Start()
        {
            driver = GetComponent<HealthDriver>();
            
            // map = new HashmapReference<GameObject, HealthController>();
            map = new Dictionary<GameObject, HealthController>();
            map.Add(this.gameObject, this);
        }
        
        public void SetHealth(int hp) { driver.SetHealth(hp); }
        public void AddHealth(int hp) { driver.AddHealth(hp); }
        public void LoseHealth(int hp) { driver.LoseHealth(hp); }

        public static bool TryGetValue(GameObject obj, out HealthController controller)
        {
            return map.TryGetValue(obj, out controller);
        }
    }
}