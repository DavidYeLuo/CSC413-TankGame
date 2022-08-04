using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems.Powerups
{
    public class RandomSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> items;
        [SerializeField] private List<GameObject> possiblePositions;
        [SerializeField] private FloatReference spawnDelayInSeconds;
        [SerializeField] private bool isSpawning;

        [Header("Debug")] 
        [SerializeField] private GameObject item;
        [SerializeField] private Vector3 pos;
    
        private void Start()
        {
            if (spawnDelayInSeconds.GetValue() < 0.01) return;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (isSpawning)
            {
                yield return new WaitForSeconds(spawnDelayInSeconds.GetValue());
                GenerateRandomItemAndPosition();
                Instantiate(item, pos, Quaternion.identity);
            }
        }

        private void GenerateRandomItemAndPosition()
        {
            item = items[Random.Range(0, items.Count)];
            pos = possiblePositions[Random.Range(0, possiblePositions.Count)].transform.position;
        }
    }
}
