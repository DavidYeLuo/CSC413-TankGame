using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Gameplay.Movement
{
    public class LookDriver : Rotator, IRequirePlayerAsset
    {
        [Header("User Settings")] 
        [SerializeField] protected float horizontalSensitivity;
        [SerializeField] protected float verticalSensitivity;
        
        public override void Look(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }

        public void GetPlayerAsset(PlayerAsset asset)
        {
            // horizontalSensitivity = asset.GetHorizontalSensitivity();
            // verticalSensitivity = asset.GetVerticalSensitivity();
            Debug.Log("TODO: Get horizontal and vertical sensitivity in player asset.");
        }
    }
}