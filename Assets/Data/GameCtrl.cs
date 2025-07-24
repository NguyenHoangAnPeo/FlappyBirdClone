using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance; // Singleton

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public GameObject gameOverPanel;
    public GameObject gameStart;
    public GameObject gameQuit;
    void Start()
    {
        gameStart.SetActive(true);
        gameQuit.SetActive(true);
    }
    public void PlayButton()
    {
        Debug.Log("Game Start");
        Time.timeScale = 1;
        gameStart.SetActive(false);
        gameQuit.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit(); // Thoát game
        Debug.Log("Thoát game"); // Dành cho debug trong editor
    }

    private int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Time.timeScale = 0;
        gameOverPanel.SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + score;
        Debug.Log("Da hien thi diem");
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
