using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int startingChunksAmount = 10;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private float chunkLength = 10f;
    [SerializeField] private float moveSpeed = 5f;
    
    private readonly GameObject[] _chunks = new GameObject[10];

    private void Start()
    {
        SpawnChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            Vector3 nextChunkPosition = transform.position + Vector3.forward * i * chunkLength;
            GameObject newChunk = Instantiate(chunkPrefab, nextChunkPosition, Quaternion.identity, chunkParent);
            
            _chunks[i] = newChunk;
        }
    }
    
    private void MoveChunks()
    {
        foreach (GameObject chunk in _chunks)
        {
            chunk.transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));
        }
    }
}
