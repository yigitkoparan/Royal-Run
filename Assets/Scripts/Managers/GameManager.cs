using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    bool GameOver = false;

    public float TimeLeft
    {
        get {return timeLeft;}
        set {timeLeft = value;}
    }

    public bool gameOver
    {
        get {return GameOver;}
        set {GameOver = value;}
    }

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (timeLeft <= 0f)
        {
            playerGameOver();
        }

        if (GameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");


    }

    void playerGameOver()
    {
        GameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
