using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int highScore;
    public bool isGameRuning = false;

    public Text txtScore;
    public Text txtHighScore;
    public Text txtGO;

    private AudioSource sound;

    public GameObject gameoverPanel;
    public GameObject startPanel;
    public GameObject blade;
    public GameObject hudScore;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("highScore");
        txtHighScore.text = "Best: " + highScore.ToString();
    }
    private void Update()
    {
        IsGameRuning();
    }
    public void IncreaseScore(int points)
    {
        score += points;

        txtScore.text = score.ToString();
        SaveScore();
    }
    public void StartGame()
    {
        isGameRuning = true;
        startPanel.SetActive(false);
        sound.Play();
        DrawSword();
    }
    public void GameOver()
    {
        SaveScore();
        foreach (var g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        isGameRuning = false;
        txtGO.text = score.ToString();
        gameoverPanel.SetActive(true);

    }
    public void Restart()
    {
        gameoverPanel.SetActive(false);
        ResetScore();
        isGameRuning = true;
        sound.Play();
        DrawSword();
    }
    private void SaveScore()
    {
        if(score > highScore)
            PlayerPrefs.SetInt("highScore", score);
    }
    private void ResetScore()
    {
        score = 0;
        txtScore.text = score.ToString();
    }
    private void IsGameRuning()
    {
        if (isGameRuning)
        {
            Time.timeScale = 1;
            hudScore.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            hudScore.SetActive(false);
        }
    }
    public void DrawSword()
    {
        blade.SetActive(true);
    }
    public void WithdrawSword()
    {
        blade.SetActive(false);
    }
}
