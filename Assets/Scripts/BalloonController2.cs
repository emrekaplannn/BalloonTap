using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class BalloonController2 : MonoBehaviour
{
    public float speed;
    public float speed2=0;
    int score = 0;
    public TextMeshProUGUI ScoreText;
    int score2 = 0;
    AudioSource AudioSource;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 6f || transform.position.x > 4f || transform.position.x < -4f)
        {
            ResetPosition();
        }
        
    }

    private void FixedUpdate()
    {
        float RandX = UnityEngine.Random.Range(-0.0001f, 0.0001f);
        speed2 += RandX;
        transform.Translate(speed2, speed, 0);
    }

    private void OnMouseDown()
    {
        score= Int32.Parse(ScoreText.text);
        score+=5;
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
