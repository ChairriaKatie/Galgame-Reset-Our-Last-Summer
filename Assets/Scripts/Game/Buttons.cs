using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Save()
    {
        PlayerPrefs.SetInt("Page",GetComponent<mainController>().currentPageIndex);
        PlayerPrefs.Save();
    }
    public void ReturnMenu()
    {
        Invoke("Menu", 0.2f);
        
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
