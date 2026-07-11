using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] float timeToIncrease = 5f;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.TimeLeft += timeToIncrease;
        }
    }
}
