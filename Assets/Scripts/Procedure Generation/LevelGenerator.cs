using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //воняет менеджером, зарефакторить, разбить на классы - генерация уровня/скорости
    [Header("References")] [SerializeField]
    private CameraController _cameraController;

    [SerializeField] private GameObject[] _chunkPrefabs;
    [SerializeField] private GameObject _checkpointChunkPrefab;
    [SerializeField] private Transform _chunkParent;

    [Header("Generation")] [SerializeField]
    private int _startingChunksAmount = 10;

    [SerializeField] private float _chunkLength = 10f;
    [SerializeField] private int _checkpointChunkInterval = 10;

    [Header("Speed")] [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _minMoveSpeed = 2f;
    [SerializeField] private float _maxMoveSpeed = 16f;

    private readonly List<GameObject> _chunks = new();
    private Camera _camera;
    private int _chunksSpawned;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        Apple.OnApplePicked += ChangeChunkMoveSpeed;
        PlayerCollisionHandler.OnHit += ChangeChunkMoveSpeed;
    }

    private void OnDisable()
    {
        Apple.OnApplePicked -= ChangeChunkMoveSpeed;
        PlayerCollisionHandler.OnHit -= ChangeChunkMoveSpeed;
    }

    private void Start()
    {
        SpawnStartingChunks();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void ChangeChunkMoveSpeed(float speedAmount)
    {
        _moveSpeed = Mathf.Clamp(_moveSpeed + speedAmount, _minMoveSpeed, _maxMoveSpeed);

        _cameraController.ChangeCameraFOV(speedAmount);
    }

    private void SpawnStartingChunks()
    {
        for (int i = 0; i < _startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 chunkSpawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject chunkToSpawn = ChooseChunkToSpawn();
        GameObject newChunk = Instantiate(chunkToSpawn, chunkSpawnPosition, Quaternion.identity, _chunkParent);
        _chunks.Add(newChunk);
        _chunksSpawned++;
    }

    private GameObject ChooseChunkToSpawn()
    {
        GameObject chunkToSpawn;

        if (_chunksSpawned % _checkpointChunkInterval == 0 && _chunksSpawned != 0)
            chunkToSpawn = _checkpointChunkPrefab;
        else
            chunkToSpawn = _chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)];

        return chunkToSpawn;
    }

    private float CalculateSpawnPositionZ()
    {
        if (_chunks.Count == 0) return 0;
        return _chunks[^1].transform.position.z + _chunkLength;
    }

    private void MoveChunks()
    {
        for (int i = 0; i < _chunks.Count; i++)
        {
            GameObject chunk = _chunks[i];
            chunk.transform.Translate(Vector3.back * (_moveSpeed * Time.deltaTime));

            if (!(chunk.transform.position.z <= _camera.transform.position.z - _chunkLength)) continue;
            _chunks.Remove(chunk);
            Destroy(chunk);
            SpawnChunk();
        }
    }
}