using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] float minObstacleSpawnTime = .2f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;

    // int obstacleSpawned = 0;
    
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    public void decreaseObstacleSpawnTime(float amount)
    {
        spawnTime -= amount;

        if(spawnTime < minObstacleSpawnTime)
        {
            spawnTime = minObstacleSpawnTime;
        }
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while(true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPos = new Vector3(Random.Range(-spawnWidth,spawnWidth),transform.position.y,transform.position.z);
            
            Instantiate(obstaclePrefab,spawnPos,Random.rotation,obstacleParent); // random.rotation instead of quaternion identity
            // obstacleSpawned++;
            yield return new WaitForSeconds(spawnTime);
            
        }
    }
}
