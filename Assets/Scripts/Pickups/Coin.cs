using UnityEngine;

public class Coin : Pickup
{
    ScoreManager scoreManager;
    
    [SerializeField] int score = 100;
    [SerializeField] AudioSource audioSource;

    public void Init(ScoreManager scoreManager)
    {
       this.scoreManager = scoreManager; 
    }

    protected override void OnPickup()
    {
        scoreManager.scoreUP(score);
        AudioSource.PlayClipAtPoint(audioSource.clip,transform.position);
    }
}
