using System;
using System.Collections;
using System.Collections.Generic;
using Systems.InputSystem;
using UnityEngine;

public class EnableOnGameplay : MonoBehaviour
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
        if (UserMode.Gameplay != mode) return;
        foreach (var objs in gameObjs)
        {
            objs.SetActive(true);
        }
    }
}
