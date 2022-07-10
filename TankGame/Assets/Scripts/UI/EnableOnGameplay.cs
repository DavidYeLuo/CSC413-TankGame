using System;
using System.Collections;
using System.Collections.Generic;
using InputSystem;
using UnityEngine;

public class EnableOnGameplay : MonoBehaviour
{
    private void Start()
    {
        InputDriver.changeModeEvent += OnModeChange;
    }

    private void OnModeChange(UserMode mode)
    {
        if (mode == UserMode.Gameplay)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
