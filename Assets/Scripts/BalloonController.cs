using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class BalloonController : MonoBehaviour
{
    public float speed;
    int score = 0;
    public TextMeshProUGUI ScoreText;

    AudioSource AudioSource;

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
            AudioSource.Play();

            SceneManager.LoadScene("GameScene");
        }
        
    }

    private void FixedUpdate()
    {
        transform.Translate(0, speed, 0);
    }

    private void OnMouseDown()
    {
        score= Int32.Parse(ScoreText.text);
        score++;
        ScoreText.text = score.ToString();

        AudioSource.Play();
        ResetPosition();
    }

    private void ResetPosition()
    {
        float RandX = UnityEngine.Random.Range(-2.5f, 2.5f);

        transform.position = new Vector2(RandX, -6f);
    }
}
