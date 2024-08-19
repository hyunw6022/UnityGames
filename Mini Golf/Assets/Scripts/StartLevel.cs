using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public Button button;
    public Level level;
    public Text levelInfoText, buttonText;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        levelName = this.gameObject.name;
        buttonText.text = levelName;
        // LoadLevelInfo();
        if(level.bestScore == 0) {
            levelInfoText.text = "Par: " + level.parScore + "\nBest Score: n/a";
        }
        else 
        {
            levelInfoText.text = "Par: " + level.parScore + "\nBest Score: " + level.bestScore;
        }
    }

    public void LoadLevel()
    {
        Debug.Log("Pressed load level button");
        SceneManager.LoadScene(levelName);
    }
    /*
    //implement when you make the save system
    void LoadLevelInfo()
    {
        LevelData data = SaveSystem.LoadLevel(levelname);
        level.levelNum = data.levelNum;
        level.bestScore = data.bestScore;
        level.parScore = data.parScore;
        level.levelComplete = data.levelComplete;
    }    
    */
}
