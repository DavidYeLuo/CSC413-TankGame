using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAsset", menuName = "PlayerAsset/Player")]
public class PlayerAsset : ScriptableObject
{
    [SerializeField] private IntReference healthAsset;
    [SerializeField] private IntReference maxHealthAsset;
    [SerializeField] private FloatReference pushForceAsset;

    public void DeepCopy(PlayerAsset asset)
    {
        // Since I can't reference this class in the body, I don't think we can do better than this.
        SetHealthAsset(Instantiate(healthAsset));
        SetMaxHealthAsset(Instantiate(maxHealthAsset));
        SetPushForceAsset(Instantiate(pushForceAsset));
    }

    public IntReference GetHealthAsset()
    {
        return healthAsset;
    }

    private void SetHealthAsset(IntReference asset)
    {
        healthAsset = asset;
    }

    public IntReference GetMaxHealthAsset()
    {
        return maxHealthAsset;
    }

    private void SetMaxHealthAsset(IntReference asset)
    {
        maxHealthAsset = asset;
    }

    public FloatReference GetPushForceAsset()
    {
        return pushForceAsset;
    }

    private void SetPushForceAsset(FloatReference asset)
    {
        pushForceAsset = asset;
    }
}