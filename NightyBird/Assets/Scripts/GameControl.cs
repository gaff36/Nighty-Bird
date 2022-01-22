using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControl : MonoBehaviour
{
    public static GameControl instance;
 
    public GameObject startText;
    public GameObject gameOverText;
    public Text scoreText;
    public Text highscoreText;
    public Text highScoreTextGameOver;

    public AudioSource swingSound, scoreSound, dieSound;

    public bool isStarted = false;
    public int score = 0;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
            else
            {
                Destroy(gameObject);
            }     
    }

    private void Start()
    {
        gameOver = false;
        

        if (PlayerPrefs.GetInt("MP_Scene") == 0 && !isStarted)
        {
            highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("MP_Highscore").ToString();
        }

        if (PlayerPrefs.GetInt("MP_Scene") == 1 && isStarted)
        {
            GetComponent<ColumnPool>().enabled = true;
        }
    }
 

    public void startScene0()
    {
        if (PlayerPrefs.GetInt("MP_Scene") == 0 && isStarted == false)
        {
            scoreText.gameObject.SetActive(true);
            startText.SetActive(false);
            GetComponent<ColumnPool>().enabled = true;
            isStarted = true;
        }
    }

    public void playSwingSound()
    {
        swingSound.Play();
    }

    public void BirdDied()
    {
        if(!gameOver)dieSound.Play();   
        gameOver = true;  
      
        if(score > PlayerPrefs.GetInt("MP_Highscore"))
        {
            PlayerPrefs.SetInt("MP_Highscore", score);
        }      
        gameOverText.SetActive(true);
        highScoreTextGameOver.text = "HIGHSCORE: " + PlayerPrefs.GetInt("MP_Highscore").ToString();

    }

    public void BirdScored()
    { 
        
        score++;
        if (score < 0) scoreText.text = "Score: 0";
        else
        scoreText.text = "Score: " + score.ToString();

        scoreSound.Play();
        scrollSpeed -= 0.11f;
    }

    public void sceneSwitcher()
    {
        SceneManager.LoadScene(1);

    }

}
