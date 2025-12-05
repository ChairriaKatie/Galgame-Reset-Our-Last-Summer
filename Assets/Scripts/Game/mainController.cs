using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainController : MonoBehaviour
{
    [Header("当前页面索引")]
    public int currentPageIndex;
    [Header("文本流速")]
    public float TextSpeed; //文本流速（字每秒）
    [Header("文本状态(newPage:刚切换至新页面,Typing:文本输出中,Done:文本输出完毕)")]
    public string State;
    [Header("存储每一页面的信息")]
    public List<Page> Pages = new List<Page>(); //页面

    public AudioClip normal;

    private float Timer;
    private int currentChar;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Page") && !(SceneManager.GetActiveScene().name == "CG"))
        {
            if(PlayerPrefs.HasKey("ifLoad") && PlayerPrefs.GetInt("ifLoad") == 1)
            {
                currentPageIndex = PlayerPrefs.GetInt("Page");
                GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = normal;
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            }
            else
            {
                currentPageIndex = 0;
            }
        }
        else
            currentPageIndex = 0;
    }
    private void Update()
    {
        if (State == "newPage")
        {
            if (currentPageIndex != 0)
            {
                if (Pages[currentPageIndex].backgroundName != Pages[currentPageIndex - 1].backgroundName)
                {
                    GameObject.Find("blackCanvas").GetComponent<SkipCanvas>().enabled = true;

                }
                else
                {
                    TurnToPage(currentPageIndex);
                }
            }
            else
            {
                TurnToPage(currentPageIndex);
            }
        }
        if (State == "Typing" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject.Find("Text Field").GetComponent<Text>().text = Pages[currentPageIndex].Text;
            GameObject.Find("TextField").GetComponent<Text>().text = Pages[currentPageIndex].Text;
        }
        if (State == "Typing" && Time.time - Timer >= 1 / TextSpeed)
        {
            if(GameObject.Find("Text Field").GetComponent<Text>().text.Length == Pages[currentPageIndex].Text.Length) State = "Done";
            else
            {
                GameObject.Find("Text Field").GetComponent<Text>().text += Pages[currentPageIndex].Text[currentChar];
                GameObject.Find("TextField").GetComponent<Text>().text += Pages[currentPageIndex].Text[currentChar];
                ++currentChar;
                Timer = Time.time;
            }
        }
        if (State == "Done" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(SceneManager.GetActiveScene().name == "Game1")
            {
                if (currentPageIndex != 1293)
                {
                    ++currentPageIndex;
                    State = "newPage";
                }
                else
                {
                    SceneManager.LoadScene("Menu");
                }
            }
            if(SceneManager.GetActiveScene().name == "CG")
            {
                if (currentPageIndex != 5)
                {
                    ++currentPageIndex;
                    State = "newPage";
                }
                else
                {
                    SceneManager.LoadScene("Menu");
                }
            }
                
        }
    }

    public void TurnToPage(int pageIndex)
    {
        if (Pages[currentPageIndex].ifShakeCamera)
            GameObject.Find("Main Camera").GetComponent<ShakeCamera>().enabled = true;
        GameObject.Find("Background").GetComponent<Image>().sprite = Pages[pageIndex].backgroundName;
        GameObject.Find("Text Field").GetComponent<Text>().text = "";
        GameObject.Find("TextField").GetComponent<Text>().text = "";
        GameObject.Find("Character Name").GetComponent<Text>().text = Pages[currentPageIndex].Title;
        GameObject.Find("Character Name (1)").GetComponent<Text>().text = Pages[currentPageIndex].Title;
        GameObject.Find("Character1").GetComponent<SpriteRenderer>().sprite = Pages[currentPageIndex].charactersSprite;
        GameObject.Find("Character1").GetComponent<SpriteRenderer>().transform.position = Pages[currentPageIndex].charactersPosition;
        if (Pages[currentPageIndex].ifChangeBGM)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = Pages[currentPageIndex].audioClip;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        }
        State = "Typing";
        currentChar = 0;
        Timer = Time.time;
    }
}
