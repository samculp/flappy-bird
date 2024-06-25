using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool canUpdateScore = true;
    public AudioSource clickSFX;
    public int highScore;
    public Text highScoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        if (canUpdateScore)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            clickSFX.Play();
        }
    }

    public void RestartGame()
    {
        canUpdateScore = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        canUpdateScore = false;

        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore = playerScore;
            PlayerPrefs.Save();
        }

        highScoreText.text = "High Score: " + highScore;

        gameOverScreen.SetActive(true);
    }
}
