using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using System.IO;
using LitJson;

public class Game : MonoBehaviour
{
    //Data数据处理
    static public Table Table;
    //Event事件管理器
    static public Event Event;
    //控制器
    static public Control Control;

    private float time = 0;


    void Start()
    {
        Control = new Control();
        Event = new Event();
        LoadData();
        Weapon.Init();
        test();


        Unit hero = new Unit(1, "英雄", 100, 400);
        Control.setHero(hero);

        Unit u1 = new Unit(2,"脚男", -300, 0);
        Unit u2 = new Unit(2,"农民", 300, 0);
        string name = "农民";
        new Timer(1, 5,new Action(createtest));

        new Brick("地板001", 0, -100);
        new Brick("地板001", -200, 300);
        new Brick("地板001", 400, 0);
        new Brick("地板001", 500, -300);
        new Brick("地板001", -400, -400);

    }

    int n = 0;
    void createtest()
    {
        new Unit(2,"农民", 300+n*50, 200-n*100);
        n += 1;
    }

    //测试
    public void test()
    {
    }

    bool time5 = false;
    public void test_update(float tm)
    {
    }



    //读取Data数据
    void LoadData()
    {
        Table = new Table();
        //读取数据
        StreamReader streamreader;
        JsonReader js;
        streamreader = new StreamReader(Application.dataPath + "/table/UnitData.json");
        js = new JsonReader(streamreader);
        Table = JsonMapper.ToObject<Table>(js);

        streamreader = new StreamReader(Application.dataPath + "/table/ItemData.json");
        js = new JsonReader(streamreader);
        Table = JsonMapper.ToObject<Table>(js);

        streamreader = new StreamReader(Application.dataPath + "/table/BrickData.json");
        js = new JsonReader(streamreader);
        Table = JsonMapper.ToObject<Table>(js);

        //for (int i = 0; i < Table.BrickData.Count; i++)
        //{
        //    Debug.Log(Table.BrickData[i].name + " " + " " + Table.BrickData[i].spritePath);
        //}
    }



    //刷新
    void Update()
    {
        float tm = Time.deltaTime;
        time = time + tm;

        Control.update(tm);
        test_update(tm);
        Unit.UnitUpdate(tm);
        Timer.TimerUpdate(tm);

        if (Control.hero.y < -2000)
        {
            Control.hero.reset();
            Control.hero.Blink(0, 300);
        }
    }

}
