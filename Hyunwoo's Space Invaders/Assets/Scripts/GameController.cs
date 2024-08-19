using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject invaderParent, ship, centerTextObject;
    public Text centerText, livesText, scoreText;
    public int score, lives;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else if ( instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        RespawnShip();
        lives = 3;
        score = 0;
    }

    public void UpdateScore()
    {
        score += 100;
        scoreText.text = score.ToString();

        if (score >= 4800 && SceneManager.GetActiveScene().name == "Level1")
        {
            centerTextObject.SetActive(true);
            Time.timeScale = 1;
            centerText.text = "Your text here";
        }



    }

    public void UpdateLives()
    {
        lives -= 1;
        livesText.text = "Lives: " + lives;
        if(lives > 0)
        {
            Invoke("RespawnShip", 2.0f);
        }
        else
        {

        }
    }

    public void RespawnShip()
    {
        Instantiate(ship, transform.position, transform.rotation);
    }
}
