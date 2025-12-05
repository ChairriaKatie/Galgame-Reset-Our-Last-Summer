using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backGround : MonoBehaviour
{
    public GameObject backgroundCanvas;
    [Header("Lerp偏移t值大小")]
    public float t;
    [Header("Lerp偏移缩放值")]
    public float lerpX;
    [Header("背景图偏移允许最大值")]
    public float pMax;

    private Sprite backGroundImage;
    private string Path = "Menu/backGround";

    private void Start()
    {

    }

    private void Update()
    {
        // 获取鼠标在屏幕上的位置
        Vector2 mousePos = Input.mousePosition;
        // 将鼠标在屏幕上的位置转换为世界空间中的位置
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z));
        if (Vector2.Distance(Vector2.zero, worldPos) * lerpX <= pMax)
            backgroundCanvas.GetComponent<RectTransform>().localPosition = Vector2.Lerp(backgroundCanvas.GetComponent<RectTransform>().localPosition, worldPos * lerpX, t);
        else
        {
            Vector3 temp = worldPos / Vector2.Distance(Vector2.zero, worldPos) * pMax;
            backgroundCanvas.GetComponent<RectTransform>().localPosition = Vector2.Lerp(backgroundCanvas.GetComponent<RectTransform>().localPosition, temp, t);
        }
    }

}
