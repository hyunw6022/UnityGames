using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveLevel(Level level, string name) {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.presistentDataPath + "/" + name + ".foo";
        string path = Application.dataPath + "/GameData/" + name + ".foo";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(level);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static LevelData LoadLevel(string name) {
        //string path = Application.persistentDataPath + "/" + name + ".foo";
        string path = Application.dataPath+ "/GameData/" + name + ".foo";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;

            return data;
            stream.Close();
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
