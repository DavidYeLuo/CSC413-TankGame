using System.Collections.Generic;
using Systems.InputSystem;
using UnityEngine;

namespace Systems.GameManager.ModeSwitcher.Subscribers
{
    public class EnableOnUI : MonoBehaviour
    {
        
        [SerializeField] private List<GameObject> gameObjs;
        private void OnEnable()
        {
            InputDriver.changeModeEvent += OnModeChange;
        }
        private void OnDisable()
        {
            InputDriver.changeModeEvent -= OnModeChange;
        }

        private void OnModeChange(UserMode mode)
        {
            if (UserMode.UI != mode) return;
            foreach (var objs in gameObjs)
            {
                objs.SetActive(true);
            }
        }
    }
}