using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using UI.Functions;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class CharacterSelectionPanel : MonoBehaviour
{
    [SerializeField] private SystemAsset systemAsset;
    [SerializeField] private PlayerSelection playerSelection;
    [SerializeField] private GameObject textPrefab;

    [Header("Debug Purpose")] 
    [SerializeField] private int numberOfPanelsCreated;

    [SerializeField] private List<GameObject> buttons;

    private void Start()
    {
        UpdatePanel();
    }

    private void OnEnable()
    {
        systemAsset.onPlayerInputAssetChange += UpdatePanel;
    }

    private void OnDisable()
    {
        systemAsset.onPlayerInputAssetChange -= UpdatePanel;
    }

    private void OnPlayerChange(PlayerInput input)
    {
        UpdatePanel();
    }
    private void UpdatePanel()
    {
        // Clear Button holders
        List<PlayerInput> list = systemAsset.GetPlayerInputs();
        
        // TODO: Find a better way to implement this.
        // Create the right amount of texts.
        
        // Add Buttons
        for (int i = numberOfPanelsCreated; i < list.Count;i++)
        {
            GameObject textGameObject = Instantiate(textPrefab);
            RectTransform rectTransform = textGameObject.GetComponent<RectTransform>();
            TextMeshProUGUI textMeshPro = textGameObject.GetComponent<TextMeshProUGUI>();
            
            rectTransform.SetParent(gameObject.transform);
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.localScale = new Vector3(1f, 1f, 1f);

            PlayerInput input = list[i];
            textMeshPro.text = String.Format("Player {0} is using {1}.", i+1, input.currentControlScheme);
            
            buttons.Add(textGameObject);
            numberOfPanelsCreated++;
        }
    }
}