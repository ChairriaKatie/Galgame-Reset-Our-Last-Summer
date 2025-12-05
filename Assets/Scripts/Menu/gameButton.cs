using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameButton : MonoBehaviour
{
    public void newGame()
    {
        PlayerPrefs.SetInt("ifLoad", 0);
        SceneManager.LoadScene("Game1");
    }
    public void cgView()
    {
        SceneManager.LoadScene("CG");
    }
    public void loadGame()
    {
        if (PlayerPrefs.HasKey("Page"))
        {
            PlayerPrefs.SetInt("ifLoad", 1);
            SceneManager.LoadScene("Game1");
        }
    }
}
