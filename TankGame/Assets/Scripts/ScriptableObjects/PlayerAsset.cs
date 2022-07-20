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
    [SerializeField] private RenderTexture minimapAsset;

    public void DeepCopy(PlayerAsset asset)
    {
        // Since I can't reference this class in the body, I don't think we can do better than this.
        SetHealthAsset(Instantiate(healthAsset));
        SetMaxHealthAsset(Instantiate(maxHealthAsset));
        SetPushForceAsset(Instantiate(pushForceAsset));

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

    private void SetMinimap(RenderTexture asset)
    {
        minimapAsset = asset;
    }

    public RenderTexture GetMinimap()
    {
        return minimapAsset;
    }
}