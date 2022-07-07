using System.Collections;
using System.Collections.Generic;
using Controllers;
using Drivers;
using UnityEngine;

public class ModeSwitcher : MonoBehaviour
{
    public void SwitchToGameplayMode()
    {
        InputController.SwitchMode(UserMode.Gameplay);
    }

    public void SwitchToUIMode()
    {
        InputController.SwitchMode(UserMode.UI);
    }
}
