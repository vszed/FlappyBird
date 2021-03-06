﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    //音效(有默认值的)
    public AudioSource audio_hit;
    public AudioSource audio_swing;
    public AudioSource audio_die;
    public AudioSource audio_point;
    public AudioSource audio_swooshing;

    //精灵
	public GameObject bkg;
    public GameObject sp_ground1;
    public GameObject sp_ground2;
    public GameObject sp_tubeDown1;
    public GameObject sp_tubeDown2;
    public GameObject sp_tubeUp1;
    public GameObject sp_tubeUp2;
    public GameObject sp_bird;
    public GameObject now_score1; //四位数字
    public GameObject now_score2;
    public GameObject now_score3;
    public GameObject now_score4;
	public GameObject high_score1; //最高记录
	public GameObject high_score2;
	public GameObject high_score3;
	public GameObject high_score4;
    public GameObject tip;
    public GameObject gameover;
    public GameObject scorePanel;
    public GameObject getReady;
    public GameObject btnOk;
	public GameObject medal;
	public GameObject newRecord;


    //数据(括号内为默认值)
    public int Nowscore;                 //当前游戏得分（0）
	public int LocalHighScore;           //本地最高得分
    public int GroundAndTubeSpeed;       //地面&水管移动速度（2）
    public float TubeDown1X;             //水管1朝下X坐标（3.3）
    public float TubeDown2X;             //水管1朝下X坐标（6.3）
    public float TubeUpDownDistance;     //水管上下间距（7.6）
    public float TubeLeftRightDistance;  //水管左右间距（3.5）
    public float TubeDownMinHeight;      //朝下水管高度要大于（2.4）
    public float TubeDownMaxHeight;      //朝下水管高度要小于（6.6）

    //开关
    public bool Tube1point;  //能否得分
    public bool Tube2point;  //能否得分
    public bool birdAlived;  //是否存活
    public bool gameBegin;   //开始游戏

    //数据单例
    private static Data gameData;

    public static Data getInstance()   //u3d特殊单例
    {
        return gameData;
    }

    private Data()
    { 
   
    }

    void Awake()
    {
        gameData = this;
    }

    // Use this for initialization
    void Start () {
		randBkg();
    }

    // Update is called once per frame
    void Update () {
		
	}

	public void upDateLocalHighScore()  //更新本地最高分
	{
		LocalHighScore = PlayerPrefs.GetInt("LocalHighScore", 0);
		if (Nowscore > LocalHighScore) {
			PlayerPrefs.SetInt ("LocalHighScore", Nowscore);
			LocalHighScore = PlayerPrefs.GetInt("LocalHighScore", 0);
			newRecord.SetActive(true);  //新纪录
		}

	}

	 void randBkg()
	{
		int value = Random.Range (0, 100);
		string path = null;

		if (value % 2 == 0) {
			path = "day"; 
		} else {
			path = "night";
		}
		var texture = (Texture2D)Resources.Load("Pictures/"+path);
		var sprite = Sprite.Create(texture, bkg.GetComponent<SpriteRenderer>().sprite.textureRect, new Vector2(0.5f, 0.5f));
		bkg.GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	public string randBirdColor()
	{
		int value = Random.Range (0, 100);

		if (value % 2 == 0) {
			return "blue"; 
		} else if (value % 3 == 0) {
			return "red";
		} else {
			return "yellow";
		}

	}
    
}
