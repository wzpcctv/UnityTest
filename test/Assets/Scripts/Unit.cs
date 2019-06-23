using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    //构造函数
    public Unit()
    {
    }
    public Unit(string name)
    {
        this.name = name;
        Debug.Log("构造函数 - 单位创建 - " + this.name);
    }

    ~Unit()
    {
        Debug.Log("删除单位 - " + this.name);
    }

    static int unitNUm = 0;
    private string name;
}
