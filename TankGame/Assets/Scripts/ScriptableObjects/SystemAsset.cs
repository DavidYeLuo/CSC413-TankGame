using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SystemAsset", menuName = "Asset/System")]
public class SystemAsset : ScriptableObject
{
    public delegate void PlayerInputAssetChange();

    public event PlayerInputAssetChange onPlayerInputAssetChange;
    
    [SerializeField] private PlayerInputsReference playerInputs;

    private void OnEnable()
    {
        playerInputs.inputsChangeEvent += InvokeOnPlayerInputsAssetChangeEvent;
    }
    private void OnDisable()
    {
        playerInputs.inputsChangeEvent -= InvokeOnPlayerInputsAssetChangeEvent;
    }

    public List<PlayerInput> GetPlayerInputs()
    {
        return playerInputs.GetPlayerInputs();
    }

    // Unused Code. Probably won't need it
    // public void SetPlayerInputs(List<PlayerInput> playerInputs)
    // {
    //     this.playerInputs.SetPlayerInputs(playerInputs);
    //     InvokeOnPlayerInputsAssetChangeEvent();
    // }
    //
    // public void SetAsset(PlayerInputsReference asset)
    // {
    //     // Sets the asset but also subscribe to the new one
    //     playerInputs.inputsChangeEvent -= InvokeOnPlayerInputsAssetChangeEvent;
    //     playerInputs = asset;
    //     playerInputs.inputsChangeEvent += InvokeOnPlayerInputsAssetChangeEvent;
    //     InvokeOnPlayerInputsAssetChangeEvent();
    // }
    //
    // public PlayerInputsReference GetAsset()
    // {
    //     return playerInputs;
    // }

    private void InvokeOnPlayerInputsAssetChangeEvent()
    {
        if (onPlayerInputAssetChange == null) return; // No subscribers
        onPlayerInputAssetChange.Invoke();
    }
}
