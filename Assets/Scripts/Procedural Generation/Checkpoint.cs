using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    [SerializeField] float timeToIncrease = 5f;
    [SerializeField] float obstacleDecreaseTimeAmount = .2f;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.TimeLeft += timeToIncrease;
            obstacleSpawner.decreaseObstacleSpawnTime(obstacleDecreaseTimeAmount);
        }
    }
}
