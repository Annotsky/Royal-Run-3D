using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDelay = 2f;
    [SerializeField] private float _destroyDelay = 10f;
    [SerializeField] private Transform _obstacleParent;
    [SerializeField] private float _spawnWith = 4f;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            GameObject obstaclePrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-_spawnWith, _spawnWith), 
                                                             transform.position.y,
                                                             transform.position.z);
            yield return new WaitForSeconds(_spawnDelay);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, _obstacleParent);
        }
    }
}
