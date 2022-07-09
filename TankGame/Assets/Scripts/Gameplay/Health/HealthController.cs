using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Health
{
    [RequireComponent(typeof(HealthDriver))]
    public class HealthController : MonoBehaviour
    {
        private static Dictionary<GameObject, HealthController> map;
        
        private HealthDriver driver;

        private void Awake()
        {
            if (map != null) return;
            map = new Dictionary<GameObject, HealthController>();
            Debug.Log("Dictionary initialized.");
        }

        private void Start()
        {
            driver = GetComponent<HealthDriver>();
            
            Debug.LogFormat("Adding {0} and {1}", gameObject, this);
            map.Add(this.gameObject, this);
        }
        
        public void SetHealth(int hp) { driver.SetHealth(hp); }
        public void AddHealth(int hp) { driver.AddHealth(hp); }
        public void SubtractHealth(int hp) { driver.SubtractHealth(hp); }

        public static bool TryAndGet(GameObject obj, out HealthController controller)
        {
            return map.TryGetValue(obj, out controller);
        }
    }
}