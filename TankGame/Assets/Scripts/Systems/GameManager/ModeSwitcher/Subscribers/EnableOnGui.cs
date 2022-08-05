using Systems.InputSystem;
using UnityEngine;

namespace Systems.GameManager.ModeSwitcher.Subscribers
{
    public class EnableOnGui : MonoBehaviour
    {
        private void Start()
        {
            InputDriver.changeModeEvent += OnModeChange;
        }

        private void OnDestroy()
        {
            InputDriver.changeModeEvent -= OnModeChange;
        }

        private void OnModeChange(UserMode mode)
        {
            if (mode == UserMode.UI)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
