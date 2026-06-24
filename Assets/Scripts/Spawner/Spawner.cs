using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Item> _itemPrefabs;

    private void Awake()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            Item randomItem = _itemPrefabs[Random.Range(0, _itemPrefabs.Count)];
            Vector3 spawnPosition = spawnPoint.transform.position;

            Instantiate(randomItem, spawnPosition, Quaternion.identity);
        }
    }
}
