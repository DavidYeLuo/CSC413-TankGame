using System;
using System.Collections;
using System.Collections.Generic;
using UI.Functions;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class CharacterSelectionPanel : MonoBehaviour
{
    [SerializeField] private PlayerSelection playerSelection;
    [SerializeField] private GameObject buttonPrefab;

    [Header("Debug Purpose")] 
    [SerializeField] private int numberOfPanelsCreated;

    [SerializeField] private List<GameObject> buttons;

    private void Start()
    {
        UpdatePanel();
    }

    private void OnEnable()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerChange;
    }

    private void OnDisable()
    {
        if (PlayerInputManager.instance == null) return; // Happens when scene is switched.
        PlayerInputManager.instance.onPlayerJoined -= OnPlayerChange;
    }

    private void OnPlayerChange(PlayerInput input)
    {
        UpdatePanel();
    }
    private void UpdatePanel()
    {
        // Clear Button holders
        // Add Buttons
        for (int i = numberOfPanelsCreated; i < playerSelection.GetNumberOfPlayersPlaying(); i++)
        {
            GameObject _gameObject = new GameObject(String.Format("Player: {0}", i));
            GameObject _Button = Instantiate(buttonPrefab);
            _Button.transform.position = Vector3.zero;
            _Button.transform.SetParent(_gameObject.transform, false);
            
            buttons.Add(_gameObject);
            _gameObject.transform.SetParent(gameObject.transform);
            
            numberOfPanelsCreated++;
        }
    }
}