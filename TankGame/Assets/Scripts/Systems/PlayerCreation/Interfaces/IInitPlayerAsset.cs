using UnityEngine;

namespace Systems.PlayerCreation.Interfaces
{
    public interface IInitPlayerAsset
    {
        public void InitPlayer(PlayerAsset asset);
        public void InitCamera(Camera cam);
        // public void InitController();
    }
}