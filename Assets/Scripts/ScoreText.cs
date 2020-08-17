using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class ScoreText : MonoBehaviour
{
    private Text scoreText;
    [SerializeField]
    private Text timerText, highscoreText;
    [SerializeField]
    private bool isPlaying;
    

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!isPlaying)
        {
            Cursor.lockState = CursorLockMode.None;
            highscoreText.text = (Mathf.Round(GameManager.HighScore * 100f) / 100f).ToString() + " s";
            timerText.text = (Mathf.Round(GameManager.currentTime * 100f) / 100f).ToString() + " s";
        }
        else
        {
            GameManager.currentTime = 0f;
            GameManager.CurrentScore = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlaying)
        {
            GameManager.currentTime += Time.deltaTime;

            timerText.text = (Mathf.Round(GameManager.currentTime * 100f) / 100f).ToString();
            scoreText.text = GameManager.CurrentScore.ToString() + " /15";
        }

        
    }
}
