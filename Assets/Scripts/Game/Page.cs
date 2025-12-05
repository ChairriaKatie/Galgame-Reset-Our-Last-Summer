using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Page   //Page类
{
    [Header("背景名")]
    public Sprite backgroundName;   //背景名
    [Header("角色名")]
    public Sprite charactersSprite;  //角色名字
    [Header("角色坐标")]
    public Vector3 charactersPosition;  //角色坐标
    [Header("是否震动")]
    public bool ifShakeCamera;
    [Header("是否改bgm")]
    public bool ifChangeBGM;
    [Header("BGM")]
    public AudioClip audioClip;
    [Header("文本标题")]
    public string Title;    //标题
    [Header("文本内容")]
    public string Text; //文本
}