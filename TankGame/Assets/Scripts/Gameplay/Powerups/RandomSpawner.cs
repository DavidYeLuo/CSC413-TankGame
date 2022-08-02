using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    [SerializeField] private List<GameObject> possiblePositions;
    [SerializeField] private float spawnDelayInSeconds;
    [SerializeField] private bool isSpawning;

    [Header("Debug")] 
    [SerializeField] private GameObject item;
    [SerializeField] private Vector3 pos;
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnDelayInSeconds);
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
