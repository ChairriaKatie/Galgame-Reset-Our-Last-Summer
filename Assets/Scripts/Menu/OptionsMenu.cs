using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("绑定游戏物体")]
    public GameObject ResolutionSettingDropdown;
    public GameObject ResolutionDropdown;
    [Header("是否显示")]
    public bool ifAppear;
    [Header("显示速率")]
    public float appearSpeed;

    private void Update()
    {
        if (ifAppear)
            GetComponent<CanvasGroup>().alpha += appearSpeed * Time.deltaTime;
        else
            GetComponent<CanvasGroup>().alpha -= appearSpeed * Time.deltaTime;
    }

    public void Appear()
    {
        ifAppear = true;
        if (PlayerPrefs.HasKey("ResolutionSetting"))
            if (PlayerPrefs.GetString("ResolutionSetting") == "FullScreen") ResolutionSettingDropdown.GetComponent<Dropdown>().value = 0;
            else ResolutionSettingDropdown.GetComponent<Dropdown>().value = 1;
        else ResolutionSettingDropdown.GetComponent<Dropdown>().value = 0;
        if (PlayerPrefs.HasKey("Resolution")) ResolutionDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("Resolution");
        else ResolutionDropdown.GetComponent<Dropdown>().value = 0;
    }
    public void Disappear()
    {
        ifAppear = false;
        switch (ResolutionDropdown.GetComponent<Dropdown>().value)
        {
            case 0: Screen.SetResolution(1920, 1080, true); PlayerPrefs.SetInt("Resolution", 0); break;
            case 1: Screen.SetResolution(1600, 900, true); PlayerPrefs.SetInt("Resolution", 1); break;
            case 2: Screen.SetResolution(1366, 768, true); PlayerPrefs.SetInt("Resolution", 2); break;
            case 3: Screen.SetResolution(1280, 720, true); PlayerPrefs.SetInt("Resolution", 3); break;
            case 4: Screen.SetResolution(1024, 576, true); PlayerPrefs.SetInt("Resolution", 4); break;
        }
        if (ResolutionSettingDropdown.GetComponent<Dropdown>().value == 0)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetString("ResolutionSetting", "FullScreen");
        }
        else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetString("ResolutionSetting", "Window");
        }
        

    }
}
