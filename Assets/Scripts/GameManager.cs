using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Score
    public int score = 0;
    public int totalKeys = 3;
    public bool gameEnded = false;

    // Lives
    public int lives = 3;
    public int maxLives = 3;

    // UI References
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject winPanel;
    public GameObject gameOverPanel;

    // Timer
    public float timeRemaining = 120f;
    private bool timerRunning = true;

    // References
    public Transform playerSpawnPoint;
    public GameObject player;

    void Start()
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        if (gameEnded) return;

        // Timer
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameOver();
            }
            UpdateUI();
        }
    }

    public void CollectKey()
    {
        if (gameEnded) return;
        score += 100;
        UpdateUI();

        // Check if all keys collected
        if (score >= totalKeys * 100)
        {
            // All keys collected - door will unlock
            Debug.Log("All keys collected! Find the exit!");
        }
    }

    public void PlayerHit()
    {
        if (gameEnded) return;

        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            // Respawn player
            player.transform.position = playerSpawnPoint.position;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;
        }
    }

    void UpdateUI()
    {
        // Keys: X / 3
        int keysCollected = score / 100;
        keysText.text = "KEYS: " + keysCollected + " / " + totalKeys;

        // Time: 120s
        timeText.text = "TIME: " + Mathf.CeilToInt(timeRemaining) + "s";

        // Score: 200
        scoreText.text = "SCORE: " + score;

         // Change hearts to text
    livesText.text = "Lives: " + lives;  // ← Shows "Lives: 3"
    }

    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;
        timerRunning = false;
        score += 200;
        UpdateUI();
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        if (gameEnded) return;
        gameEnded = true;
        timerRunning = false;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}