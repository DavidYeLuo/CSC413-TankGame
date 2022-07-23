using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SystemAsset", menuName = "Asset/System")]
public class SystemAsset : ScriptableObject
{
    private Dictionary<int, PlayerInput> playerInputs;

    public Dictionary<int, PlayerInput> GetPlayerInputs()
    {
        return playerInputs;
    }

    public void SetPlayerInputs(Dictionary<int, PlayerInput> playerInputs)
    {
        this.playerInputs = playerInputs;
    }
}
