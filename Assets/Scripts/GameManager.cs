using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public List<DamageOnCollision> obstacleList;
    public Pawn pawn;
    public CameraFocusPoint focusPoint;
    public static bool gameOver = false;
    public static bool isPaused = false;
    public static bool isGameStarted = false;
    public GameObject pauseMenuUI;
    public GameObject titleScreenUI;
    public GameObject scoreManager;
    public GameObject gameplayUI;
    public GameObject creditsUI;
    public GameObject leaderboardUI;
    public LeaderboardManager leaderboardManager;
    public GameObject victoryUI;
    public GameObject gameOverUI;
    public static AudioSource backgroundMusic;
    public AudioListener gameOverAudioListener;
    public Camera gameOverCamera;
    public static int score;
    public static int lives;
    public static int timeRemaining;
    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        obstacleList = new List<DamageOnCollision>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        gameOverAudioListener.enabled = false;
        gameOverCamera.enabled = false;
        pauseMenuUI.SetActive(false);
        titleScreenUI.SetActive(true);
        gameplayUI.SetActive(false);
        creditsUI.SetActive(false);
        leaderboardUI.SetActive(false);
        victoryUI.SetActive(false);
        gameOverUI.SetActive(false);
        score = 0;
        lives = 1;
        timeRemaining = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (pawn == null && !gameOver)
        {
            Debug.Log("Failure");
            gameOverAudioListener.enabled = true;
            gameOverCamera.enabled = true;
            gameOverUI.SetActive(true);
            gameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                UnpauseGame();

            }
            else
            {
                PauseGame();
            }
        }
    }

    public static void IncreaseScore(int amount)
    {
        score += amount;
        if (gameManager != null && gameManager.scoreManager != null && gameManager.scoreManager.GetComponent<ScoreManager>() != null)
        {
            Debug.Log("Passed the score increase checks");
            gameManager.scoreManager.GetComponent<ScoreManager>().UpdateScore();
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        titleScreenUI.SetActive(false);
        gameplayUI.SetActive(true);
        StartCoroutine(StartTimer());
    }

    private System.Collections.IEnumerator StartTimer()
{
    while (timeRemaining > 0 && !gameOver)
    {
        yield return new WaitForSeconds(1f);
        if (!isPaused)
        {
            timeRemaining--;
        }
    }
    if (timeRemaining == 0)
    {
        Victory();
    }
}
    public void Victory()
    {
        Debug.Log("Victory!");
        victoryUI.SetActive(true);
        gameOver = true;
        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.Save();
        if (leaderboardManager != null)
        {
            leaderboardManager.UpdateScore();
        }
    }

    public void UnpauseGame()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void DisplayCredits()
    {
        creditsUI.SetActive(true);
    }

    public void HideCredits()
    {
        creditsUI.SetActive(false);
    }

    public void DisplayLeaderboard()
    {
        leaderboardUI.SetActive(true);
    }

    public void HideLeaderboard()
    {
        leaderboardUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
