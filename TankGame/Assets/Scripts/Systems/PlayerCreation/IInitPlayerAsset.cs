using System.Collections.Generic;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Systems.PlayerCreation
{
    public interface IInitPlayerAsset
    {
        public void InitPlayer(PlayerAsset asset);
    }
}