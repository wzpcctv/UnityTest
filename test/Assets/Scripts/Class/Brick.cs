using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick
{
    static public List<Brick> BrickList = new List<Brick>();
    static private int indexId_cal = 0;

    public GameObject gameObj;
    public int id;
    public int indexId;

    public string name;
    public Block block;
    public Effect effect;
    public float x;
    public float y;
    public float angle;
    public float size;
    public bool blockable;

    public Brick(string name, float x, float y)
    {
        Debug.Log("构造函数 - 砖块 - " + name);
        //基础数据
        this.id = Table.getBrickId(name);
        this.indexId = (indexId_cal += 1);
        this.name = name;
        this.x = x;
        this.y = y;
        this.blockable = Table.BrickData[id].blockable;
        //游戏对象
        this.gameObj = new GameObject();

        Debug.Log( name+"path:"+Table.BrickData[id].spritePath);
        //图像
        Sprite sprite = Resources.Load(Table.BrickData[id].spritePath, typeof(Sprite)) as Sprite;
        this.effect = new Effect(this ,0, 0, 0);
        if (this.blockable)
        {
            this.block = new Block(0, 0, Table.BrickData[id].blockWidth/100, Table.BrickData[id].blockHight/100);
        }
        //碰撞体
        //运动体
        BrickList.Add(this);
    }
}
