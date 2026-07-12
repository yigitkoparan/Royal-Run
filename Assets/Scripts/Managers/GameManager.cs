using System.Collections; // Required for Coroutines / IEnumerator
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;
    [SerializeField] float restartTime = 2f;

    float timeLeft;
    bool GameOver = false;

    public float TimeLeft
    {
        get { return timeLeft; }
        set { timeLeft = value; }
    }

    public bool gameOver
    {
        get { return GameOver; }
        set { GameOver = value; }
    }

    void Start()
    {
        Time.timeScale = 1f; 
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
        
        if (GameOver) return; 

        GameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        
        Time.timeScale = 0.1f; 
        
        StartCoroutine(ReloadSceneAfterDelay());
    }

    
    IEnumerator ReloadSceneAfterDelay()
    {
        
        yield return new WaitForSecondsRealtime(restartTime);
        
        Time.timeScale = 1f; 
        
        SceneManager.LoadScene("MainLevel");
    }
}
