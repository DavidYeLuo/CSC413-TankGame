using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.PlayerCreation
{
    public class SpawnDriver : MonoBehaviour
    {
        [SerializeField] private List<GameObject> spawnLocations;
        private int count;

        private void Start()
        {
            count = 0;
        }
        
        public Vector3 GetSpawnLocation()
        {
            Vector3 spawnLoc = spawnLocations[count % spawnLocations.Count].transform.position;
            count++;
            return spawnLoc;
        }
    }
}