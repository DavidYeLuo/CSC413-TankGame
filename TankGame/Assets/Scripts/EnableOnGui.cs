using System;
using System.Collections;
using System.Collections.Generic;
using Drivers;
using UnityEngine;

public class EnableOnGui : MonoBehaviour
{
    private void Start()
    {
        InputDriver.changeModeEvent += OnModeChange;
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
