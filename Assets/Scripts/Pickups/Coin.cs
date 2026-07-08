using UnityEngine;

public class Coin : Pickup
{
    ScoreManager scoreManager;
    
    [SerializeField] int score = 100;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        scoreManager.scoreUP(score);
    }
}
