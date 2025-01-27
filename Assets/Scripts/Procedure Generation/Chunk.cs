using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject coinPrefab;
    
    [SerializeField] private float appleSpawnChance = 0.3f;
    [SerializeField] private float coinSpawnChance = 0.5f;
    [SerializeField] private float coinSeparationLenght = 2f;
    
    [SerializeField] private float[] lanes = { -2.5f, 0f, 2,5f };
    
    private readonly List<int> _availableLanes = new() { 0, 1, 2 };

    private void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    private void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (_availableLanes.Count <= 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    private void SpawnApple()
    {
        if (Random.value > appleSpawnChance || _availableLanes.Count <= 0) return;
        
        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    private void SpawnCoins()
    {
        if (Random.value > coinSpawnChance || _availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        const int maxCoinsToSpawn = 5;
        int coinsToSpawn = Random.Range(0, maxCoinsToSpawn);
        
        float topOfChunkZPosition = transform.position.z + (coinSeparationLenght * 2f);
        
        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPosition - i * coinSeparationLenght;
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    private int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, _availableLanes.Count);
        int selectedLane = _availableLanes[randomLaneIndex];
        _availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
