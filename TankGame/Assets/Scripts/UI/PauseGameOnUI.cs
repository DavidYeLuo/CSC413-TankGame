using System.Collections;
using System.Collections.Generic;
using Systems.InputSystem;
using UnityEngine;

public class PauseGameOnUI : MonoBehaviour
{
    private void OnEnable()
    {
        InputDriver.changeModeEvent += OnEventChange;
    }

    private void OnDisable()
    {
        InputDriver.changeModeEvent -= OnEventChange;
    }

    private void OnEventChange(UserMode mode)
    {
        if (mode == UserMode.UI)
        {
            Time.timeScale = 0;
        }
    }
}
