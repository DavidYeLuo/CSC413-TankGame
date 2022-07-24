using ScriptableObjects;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Gameplay.Rotation
{
    public class LookDriver : Rotator, IRequirePlayerAsset
    {
        [Header("User Settings")] 
        [SerializeField] protected FloatReference horizontalSensitivity;
        [SerializeField] protected FloatReference verticalSensitivity;
        
        public override void Look(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }

        public void GetPlayerAsset(PlayerAsset asset)
        {
            horizontalSensitivity = asset.GetHorizontalSensitivity();
            verticalSensitivity = asset.GetVerticalSensitivity();
        }
    }
}