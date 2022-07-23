using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAsset", menuName = "PlayerAsset/Player")]
public class PlayerAsset : ScriptableObject
{
    [Header("Health")]
    [SerializeField] private IntReference healthAsset;
    [SerializeField] private IntReference maxHealthAsset;
    [Header("Movement")]
    [SerializeField] private FloatReference pushForceAsset;
    [Header("Look Rotation")] 
    [SerializeField] private FloatReference horizontalSensitivity;
    [SerializeField] private FloatReference verticalSensitivity;
    [Header("Minimap")]
    [SerializeField] private RenderTexture minimapAsset;

    public void DeepCopy(PlayerAsset asset)
    {
        // Since I can't reference this class in the body, I don't think we can do better than this.
        
        // Health
        SetHealthAsset(Instantiate(healthAsset));
        SetMaxHealthAsset(Instantiate(maxHealthAsset));
        
        // Movement
        SetPushForceAsset(Instantiate(pushForceAsset));
        
        // Look Rotation
        SetHorizontalSensitivity(Instantiate(horizontalSensitivity));
        SetVerticalSensitivity(Instantiate(verticalSensitivity));

        // Minimap
        minimapAsset = new RenderTexture(asset.minimapAsset.width, asset.minimapAsset.height, asset.minimapAsset.depth);
        minimapAsset.Create();
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

    public FloatReference GetHorizontalSensitivity()
    {
        return horizontalSensitivity;
    }

    public FloatReference GetVerticalSensitivity()
    {
        return verticalSensitivity;
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

    private void SetHorizontalSensitivity(FloatReference asset)
    {
        horizontalSensitivity = asset;
    }

    private void SetVerticalSensitivity(FloatReference asset)
    {
        verticalSensitivity = asset;
    }

    private void SetMinimap(RenderTexture asset)
    {
        minimapAsset = asset;
    }

    public RenderTexture GetMinimap()
    {
        return minimapAsset;
    }
}