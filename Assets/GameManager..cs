using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Playing, Won, Lost }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Progression")]
    public int targetScoreToWin = 5;
    public int currentScore = 0;
    public GameState currentState = GameState.Playing;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        if (currentState != GameState.Playing) return;

        currentScore += amount;
        Debug.Log($"Score: {currentScore} / {targetScoreToWin}");

        if (currentScore >= targetScoreToWin)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        if (currentState != GameState.Playing) return;
        currentState = GameState.Won;
        Debug.Log("VICTORY! You completed the course.");
    }

    public void GameOver()
    {
        if (currentState != GameState.Playing) return;
        currentState = GameState.Lost;
        Debug.Log("GAME OVER! You failed.");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}