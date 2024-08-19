using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int currSwing, parScore;
    public Text levelText;
    public Level level;
    public GameObject overlay;

    void Start()
    {
        //non yet
        LoadLevelInfo();
        overlay = GameObject.Find("UI Overlay");
        overlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
    
    void UpdateText()
    {
        levelText.text = "Par: " + parScore + "\nCurrent Swings: "+ currSwing + "\nBest Score: " + level.bestScore;
    }

    public void LevelComplete()
    {
        overlay.SetActive(true);
        ShowStars();
        if (currSwing < level.bestScore || level.bestScore == 0)
        {
            level.bestScore = currSwing;
        }
        Debug.Log("You won!");
        SaveLeveInfo();
    }

    public void BackToMenus()
    {
        SceneManager.LoadScene("Menus");
    }

    public void SaveLeveInfo()
    {
        string levelName = SceneManager.GetActiveScene().name;
        SaveSystem.SaveLevel(level, levelName);
    }

    void ShowStars()
    {
        int delta = currSwing - level.parScore;
        int numStars = 0;

        if (delta <= 0)
        {
            numStars = 3;
        }
        else if (delta == 1)
        {
            numStars = 2;
        }
        else if (delta == 2)
        {
            numStars = 1;
        }

        //Update stars in UI overlay
        for (int i = 1; i <= numStars ; i++)
        {
            Image star = GameObject.Find(i.ToString()).GetComponent<Image>();
            star.sprite = GameObject.Find("star").GetComponent<Image>().sprite;
        }
    }

    public void LoadLevelInfo()
    {
        string levelName = SceneManager.GetActiveScene().name;
        LevelData data = SaveSystem.LoadLevel(levelName);
        level.levelNum = data.levelNum;
        level.bestScore = data.bestScore;
        level.parScore = data.parScore;
    }

    public void RestartLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelName);
    }

    public void NextLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;
        
        if(levelName == "Level 1")
        {
            SceneManager.LoadScene("Level 2");
        }
        else if(levelName == "Level 2")
        {
            SceneManager.LoadScene("Level 3");
        }
        else if(levelName == "Level 3")
        {
            SceneManager.LoadScene("Level 4");
        }
        else if(levelName == "Level 4")
        {
            SceneManager.LoadScene("Level 5");
        }
        else if(levelName == "Level 5")
        {
            SceneManager.LoadScene("Level 6");
        }
    }
}
