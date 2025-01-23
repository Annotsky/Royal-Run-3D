using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnDelay = 2f;

    private void Update()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
