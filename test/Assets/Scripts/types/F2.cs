using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//所有单位，特效，等object的基础类
//因unity已有object，自定义使用F2作为区分
abstract public class F2
{
    //游戏对象
    public GameObject gameObj;
    //坐标
    public float x;
    public float y;
    //角度
    public float angle;
    //是否可碰撞
    public bool blockable = true;
    //碰撞体
    public Block block;

    public abstract void Move(Vector2 vec2);
    public abstract string getName();
}
