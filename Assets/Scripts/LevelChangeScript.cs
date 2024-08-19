using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeScript : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey && SceneManager.GetActiveScene().name == "Menus")
        {
            SceneManager.LoadScene("Level1");
        }

        if (Input.GetKey(KeyCode.Return)&& SceneManager.GetActiveScene().name =="Level1")
        {
            SceneManager.LoadScene("Level2");
        }




    }
}
