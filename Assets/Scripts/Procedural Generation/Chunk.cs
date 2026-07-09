using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeperationLength = 2f;

    [SerializeField] float[] lanes = {-2.5f, 0f, 2.5f};

    LevelGenerator levelGenerator;
    ScoreManager scoreManager;
    
    List<int> availableLanes = new List<int> {0,1,2};

    void Start()
    {
        spawnFences();
        spawnApple();
        spawnCoin();
    }

    public void Init(LevelGenerator levelGenerator,ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
    }

    void spawnFences()
    {
        int fencesToSpawn = Random.Range(0,lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
            int selectedLane = selectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], fencePrefab.transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void spawnApple()
    {
        if(Random.value > appleSpawnChance) return;
        if(availableLanes.Count <= 0) return;

        int selectedLane = selectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], fencePrefab.transform.position.y, transform.position.z);
        Apple newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.Init(levelGenerator);
    }

    void spawnCoin()
    {
        if(Random.value > coinSpawnChance) return;
        if(availableLanes.Count <= 0) return;

        int selectedLane = selectLane();

        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1,maxCoinsToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2f);

        for(int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeperationLength);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], fencePrefab.transform.position.y, spawnPositionZ);
            Coin newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();
            newCoin.Init(scoreManager);
        }

    }

    int selectLane()
    {
        int randomLane = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLane];
        availableLanes.RemoveAt(randomLane);
        return selectedLane;
    }
}
