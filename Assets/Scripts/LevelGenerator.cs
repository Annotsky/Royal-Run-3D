using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int startingChunksAmount = 10;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private float chunkLength = 10f;
    [SerializeField] private float moveSpeed = 5f;

    private readonly List<GameObject> _chunks = new();

    private void Start()
    {
        SpawnStartingChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        
        Vector3 chunkSpawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPosition, Quaternion.identity, chunkParent);

        _chunks.Add(newChunk);
    }
    
    private float CalculateSpawnPositionZ()
    {
        if (_chunks.Count == 0) return 0;
        return _chunks[^1].transform.position.z + chunkLength;
    }

    private void MoveChunks()
    {
        for (int i = 0; i < _chunks.Count; i++)
        {
            GameObject chunk = _chunks[i];
            chunk.transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));

            if (!(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)) continue;
            _chunks.Remove(chunk);
            Destroy(chunk);
            SpawnChunk();
        }
    }
}
