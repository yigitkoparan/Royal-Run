using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] GameObject checkpointChunk;
    [SerializeField] Transform chunkParent;
    [SerializeField] ScoreManager scoreManager;

    [Header("Level Settings")][Tooltip("Amount of chunks to start with")]
    [SerializeField] int startingChunksAmount = 12;
    [Tooltip("Do not change chunk lenght value unless chunk prefab size reflects change!")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 15f;
    [SerializeField] int checkpointCount = 8;

    //GameObject[] chunks = new GameObject[12];
    List<GameObject> chunks = new List<GameObject>(); 

    int chunksSpawned = 0;

    void Start()
    {
        SpawnStartingChunks();
    }

    void Update()
    {
        moveChunks();
    }

    public void changeChunkMoveSpeed(float speedAmount)
    {
        moveSpeed += speedAmount;

        if(moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }
        else if(moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);

        cameraController.changeCameraFOV(speedAmount);
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

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

        GameObject chunkToSpawn;

        chunkToSpawn = ChooseChunkToSpawn();

        GameObject newChunkGO = Instantiate(chunkToSpawn, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);

    }

    private GameObject ChooseChunkToSpawn()
    {
        GameObject chunkToSpawn;
        if (chunksSpawned % checkpointCount == 0 && chunksSpawned != 0)
        {
            chunkToSpawn = checkpointChunk;
            chunksSpawned++;
        }
        else
        {
            chunkToSpawn = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
            chunksSpawned++;
        }

        return chunkToSpawn;
    }

    private float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;
    
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            //spawnPositionZ = transform.position.z + (chunks.Count * chunkLength);
            spawnPositionZ = chunks[chunks.Count-1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    void moveChunks()
    {
        for(int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if(chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
