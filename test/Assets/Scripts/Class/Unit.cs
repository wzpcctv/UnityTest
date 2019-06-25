using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : F2
{
    //构造函数
    public Unit()
    {
    }

    public Unit(string name, float x, float y)
    {
        Debug.Log("构造函数 - 单位创建 - " + name);

        int id = Table.getUnitId(name);

        this.gameObj = new GameObject();

        this.name = name;
        this.x = x;
        this.y = y;

        Sprite sprite = Resources.Load(Table.UnitData[id].spritePath, typeof(Sprite)) as Sprite;
        Debug.Log("spritePath " + name);

        if (name == "农民")
        {
            this.action = new Action(this, 1f, 0);
        }
        else
        {
            this.action = new Action(this, -1f, 0);
        }

        this.effect = new Effect(this, sprite, 0, 0, 0);

        this.block = new Block(this, 0, 0, 1, 1);

        UnitList.Add(this);
    }

    ~Unit()
    {
        Debug.Log("删除单位 - " + this.name);
        GameObject.Destroy(gameObj);
    }

    public void update(float tm)
    {
        this.action.update(tm);
    }

    public override void Move(Vector2 vec2)
    {
        if (this.block.canMove(vec2))
        {
            this.x += vec2.x;
            this.y += vec2.y;
            gameObj.transform.Translate(vec2);
        }
    }


    public override string getName()
    {
        return this.name;
    }

    public string name;
    public Effect effect;
    public Block block;
    public Action action;
    public int id;

    static public List<Unit> UnitList = new List<Unit>();
}
