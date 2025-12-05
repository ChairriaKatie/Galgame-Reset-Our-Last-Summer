using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipCanvas : MonoBehaviour
{
    public int state;
    public float speed;
    void OnEnable()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == 0)
        {
            GetComponent<CanvasGroup>().alpha += speed * Time.deltaTime;
            if (GetComponent<CanvasGroup>().alpha >= 1)
                Invoke("Wait", 0.2f);
        }
        if(state == 1)
        {
            GetComponent<CanvasGroup>().alpha -= speed * Time.deltaTime;
            if (GetComponent<CanvasGroup>().alpha <= 0)
            {
                GetComponent<CanvasGroup>().alpha = 0;
                this.enabled = false;
            }
                
        }
    }
    void Wait()
    {
        GameObject.Find("Page Controller").GetComponent<mainController>().TurnToPage(GameObject.Find("Page Controller").GetComponent<mainController>().currentPageIndex);
        state = 1;
    }
}
