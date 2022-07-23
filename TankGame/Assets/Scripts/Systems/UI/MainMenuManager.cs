using System;
using System.Collections;
using System.Collections.Generic;
using Systems.InputSystem;
using UI;
using UI.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SystemAsset systemAsset;
    [SerializeField] private Navigable startPanel;
    
    [Header("Driver")]
    // Used to get device to play
    [SerializeField] private InputDriver inputDriver;

    [Header("For Debug purpose")] 
    [SerializeField] private Navigable currentPanel;
    [SerializeField] private Navigable previousPanel;

    private void Start()
    {
        systemAsset.SetPlayerInputs(null); // resets the playerinputs
        currentPanel = startPanel;
        currentPanel.gameObject.SetActive(true);
    }

    public void GotoPreviousPanel()
    {
        Navigate(previousPanel);
    }

    public void Navigate(Navigable panel)
    {
        currentPanel.Navigate(panel);
        previousPanel = currentPanel;
        currentPanel = panel;
    }

    public void SaveSystemAsset()
    {
        InputDriver.Instance.SavePlayersControl();
    }

    public void EnablePlayerJoin()
    {
        PlayerInputManager.instance.EnableJoining();
    }

    public void DisablePlayerJoin()
    {
        PlayerInputManager.instance.DisableJoining();
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void LoadScene(String scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    
    public void EnterGameplay()
    {
        // Switch scenes here.
        InputController.SwitchMode(UserMode.Gameplay);
    }
}
