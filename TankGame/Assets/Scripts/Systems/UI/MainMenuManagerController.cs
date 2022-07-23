using System;
using System.Collections;
using System.Collections.Generic;
using Systems;
using Systems.InputSystem;
using Systems.UI;
using UI;
using UI.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManagerController : MonoBehaviour
{
    [Header("Driver")]
    // Used to get device to play
    [SerializeField] private MainMenuManagerDriver managerDriver;

    public void GotoPreviousPanel()
    {
        managerDriver.GotoPreviousPanel();
    }

    public void Navigate(Navigable panel)
    {
        managerDriver.Navigate(panel);
    }

    public void SaveSystemAsset()
    {
        managerDriver.SaveSystemAsset();
    }

    public void EnablePlayerJoin()
    {
        managerDriver.EnablePlayerJoin();
    }

    public void DisablePlayerJoin()
    {
        managerDriver.DisablePlayerJoin();
    }

    public void ExitApplication()
    {
        managerDriver.ExitApplication();
    }

    public void LoadScene(string scene)
    {
        managerDriver.LoadScene(scene);
    }
    
    public void EnterGameplay()
    {
        managerDriver.EnterGameplay();
    }
}
