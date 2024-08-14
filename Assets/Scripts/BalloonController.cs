using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class BalloonController : MonoBehaviour
{
    public float speed;
    public int score = 0;
    int bestScore;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject gameOverPanel;
    public GameObject balloon1;
    public GameObject balloon2;
    public GameObject balloon3;
    public GameObject balloon4;
    public GameObject balloon5;

    AudioSource AudioSource;

    void Start()
    {
        gameOverPanel.SetActive(false);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 4f)
        {
            GameOver();
            //AudioSource.Play();

            //SceneManager.LoadScene("GameScene");
        }

    }
    void GameOver()
    {
        balloon1.SetActive(false);
        balloon2.SetActive(false);
        balloon3.SetActive(false);
        balloon4.SetActive(false);
        balloon5.SetActive(false);

        score = Int32.Parse(ScoreText.text);

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }
        bestScoreText.text = bestScore.ToString();
        gameOverPanel.SetActive(true);

        
        
    }



    private void FixedUpdate()
    {
        transform.Translate(0, speed, 0);
    }

    private void OnMouseDown()
    {
        score = Int32.Parse(ScoreText.text);
        score++;
        ScoreText.text = score.ToString();

        AudioSource.Play();
        ResetPosition();
    }

    private void ResetPosition()
    {
        float RandX = UnityEngine.Random.Range(-2.05f, 2.05f);

        transform.position = new Vector2(RandX, -6f);
    }

    public void RestartGame()
    {
        // Restart the game logic
        score = 0;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }
}