using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Level : ScriptableObject
{
    public int levelNum;
    public int bestScore;
    public int parScore;
    public bool levelComplete;
}
