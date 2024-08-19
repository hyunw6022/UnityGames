using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class LevelData
{
    public int levelNum;
    public int bestScore;
    public int parScore;
    public bool levelComplete;

    public LevelData(Level level)
    {
        levelNum = level.levelNum;
        bestScore = level.bestScore;
        parScore = level.parScore;
        levelComplete = level.levelComplete;
    }
}
