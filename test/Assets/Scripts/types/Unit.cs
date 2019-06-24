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

        this.gameObj = new GameObject();

        this.name = name;
        this.x = x;
        this.y = y;

        Sprite sprite;
        if (name == "农民")
        {
             sprite = Resources.Load("units\\body", typeof(Sprite)) as Sprite;
            action = new Action(this,1f, 0);
        }else if (name == "脚男")
        {
            sprite = Resources.Load("units\\body2", typeof(Sprite)) as Sprite;
            action = new Action(this,-1f, 0);
        }
        else
        {
            sprite = Resources.Load("units\\body0", typeof(Sprite)) as Sprite;
        }

        this.effect = new Effect(this, sprite, 0, 0, 0);

        this.block = new Block(this, 0, 0, 1, 1);
        Debug.Log(this.block);

        Game.units[Game.unitsNum] = this;
        id = Game.unitsNum;
        Game.unitsNum += 1;
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
        //gameObj.transform.Translate(new Vector2(this.x,this.y));
        if (this.block.canMove(vec2))
        {
            this.x += vec2.x;
            this.y += vec2.y;
            gameObj.transform.Translate(vec2);
        }
    }


    public override string getName() {
        return this.name;
    }

    static int unitNUm = 0;
    public string name;
    public Effect effect;
    public Block block;
    public Action action;
    public int id;
}
