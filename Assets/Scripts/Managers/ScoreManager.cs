using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] GameManager gameManager;

    int score = 0;


    public void scoreUP(int amount)
    {
        if(gameManager.gameOver) return;
        
        score += amount;
        text.text = score.ToString();
        
    }
}
