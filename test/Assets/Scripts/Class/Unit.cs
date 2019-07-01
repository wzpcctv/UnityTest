using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Unit
{
    static public List<Unit> UnitList = new List<Unit>();
    static private int indexId_cal = 0;

    public bool removed = false;
    public string type = "单位";
    public GameObject gameObj;
    public float x;
    public float y;
    public Block block;
    public bool blockable = true;
    public int id;//在UnitData中的id
    public int indexId;//在UnitList中的indexId
    public string name;
    public bool alive = true;
    public int team_id;//1自己，2盟友，3敌人
    public int blockUnit = 0;//0不发生碰撞，1发生碰撞可通行，2发生碰撞不可通行
    public int blockBrick = 0;//0不发生碰撞，1发生碰撞可通行，2.发生碰撞不可通行
    public bool fly = false;//飞行单位，不受重力影响
    public Weapon weapon;
    public Effect effect;
    public Active active;
    public AI ai;
    public Attribute attribute;

    public Brick lastBrick;//最后碰撞到的brick
    public Unit lastUnit;//最后碰撞到的unit
    public Unit owner;//马甲



    //单位碰撞
    public List<Action<Unit,Unit>> eventBlockUnit;

    //信息
    public string ToString()
    {
        return type + ":" + name + " id:" + id + " indexId：" + indexId;
    }
    public string info()
    {
        string str = type + ":" + name + " id:" + id + " indexId：" + indexId;
        str += "\n";
        str += attribute.attributeInfo();
        return str;
    }
    public void showInfo()
    {
        Debug.Log(info());
    }


    //构造函数
    public Unit(int team_id, string name, float x, float y)
    {
        Debug.Log("构造函数 - 单位创建 - " + name);
        //基础数据
        this.id = Table.getUnitId(name);
        this.indexId = (indexId_cal += 1);
        this.team_id = team_id;
        this.name = name;
        this.x = x;
        this.y = y;

        //Table属性初始化
        Table.UnitDataInit(this);
        //游戏对象
        this.gameObj = new GameObject();
        this.effect = new Effect(this, 0, 0, 0);
        //碰撞体
        this.block = new Block(0, 0, 50, 50);
        this.blockable = true;
        //运动体
        this.active = new Active(this);
        //属性
        this.attribute = new Attribute(this);


        //加入UnitList中
        UnitList.Add(this);
    }


    //析构函数
    ~Unit()
    {
        Debug.Log("析构函数 - " + this.info());
    }


    //删除单位
    public void Remove()
    {
        if (removed)
        {
            return;
        }
        removed = true;

        Debug.Log("删除单位函数 - " + this.info());
        GameObject.Destroy(this.gameObj);
        if (this.ai != null)
        {
            this.ai.Remove();
            this.ai = null;
        }
        if (this.active != null)
        {
            this.active.Remove();
            this.active = null;
        }
        if (this.block != null)
        {
            this.block.Remove();
            this.block = null;
        }
        if (this.weapon != null)
        {
            this.weapon.Remove();
            this.weapon = null;
        }

        lastBrick = null;
        lastUnit = null;
        owner = null;


        //删除事件
        if (eventBlockUnit != null)
        {
            eventBlockUnit.Clear();
            eventBlockUnit = null;
        }
    }


    //添加单位碰撞事件
    public void addEventBlockUnit(Action<Unit,Unit> action)
    {
        if (eventBlockUnit == null) {
            eventBlockUnit = new List<Action<Unit, Unit>>();
        }
        eventBlockUnit.Add(action);
    }
    public void onBlockUnit(Unit target)
    {
        if (eventBlockUnit == null)
        {
            return;
        }
        for (int i = eventBlockUnit.Count - 1;i >= 0; i--)
        {
            eventBlockUnit[i](this,target);
        }
    }

    //重置所有状态
    public void reset()
    {
        if (active != null)
        {
            active.reset();
        }
    }

    //添加武器
    public void addWeapon(string name)
    {
        Weapon wp = Weapon.getWeapon(name);
        if (wp != null)
        {
            wp.owner = this;
            this.weapon = wp;
        }
        else
        {
            Debug.Log("没有找到武器" + name);
        }
    }
    
    //开火
    public void Fire()
    {
        if (weapon != null)
        {
            weapon.Shot();
        }
    }

    //杀死
    public void kill()
    {
        Remove();
    }

    public void Blink(float x, float y)
    {
        this.x = x;
        this.y = y;
        gameObj.transform.position = new Vector2(this.x / 100, this.y / 100);
    }

    //移动
    public bool Move(Vector2 vec2)
    {
        if (this.block != null)
        {
            Vector2 vNew = this.block.canMove(this, vec2);

            //if (Math.Abs(vNew.x) < 0.01)
            //{
            //    vNew.x = 0;
            //}
            //if (Math.Abs(vNew.y) < 0.01)
            //{
            //    vNew.y = 0;
            //}
            this.x += vNew.x;
            this.y += vNew.y;
            //this.x = ((float)((int)((this.x) * 100))) / 100;
            //this.y = ((float)((int)((this.x) * 100))) / 100;
            //gameObj.transform.position = new Vector3(this.x, this.y);
            //gameObj.transform.localPosition = new Vector2(vNew.x/100,vNew.y/100);
            gameObj.transform.position = new Vector2(this.x / 100, this.y / 100);

            //if (Math.Abs(vNew.x - vec2.x) < 0.01 && Math.Abs(vNew.y - vec2.y) < 0.01)
            if (Math.Abs(vNew.x - vec2.x) < 0.01 && Math.Abs(vNew.y - vec2.y) < 0.01)
            {
                return true;
            }
            else
            {
                //Debug.Log(vec2.x + " " + vec2.y);
                //Debug.Log(vNew.x + " " + vNew.y);
                //Debug.Log("stuck");
                return false;
            }
        }
        return false;
    }
    public bool MoveX(float x)
    {
        return Move(new Vector2(x, 0));
    }
    public bool MoveY(float y)
    {
        return Move(new Vector2(0, y));
    }

    //旋转
    public void rotate(float ang)
    {
        //this.gameObj.transform.Rotate(new Vector3(0, 0, ang));
        this.gameObj.transform.Rotate(0, 0, ang);
    }

    //设置生命时间
    public void setLifeTime(float time)
    {
        new Timer(time, new Action(kill));
    }

    public void update(float tm)
    {
        if (removed)
        {
            UnitList.Remove(this);
            return;
        }

        if (alive == false)
        {
            Remove();
        }
        else
        {
            if (active != null)
            {
                //ActiveUpdate(tm);
                active.update(tm);
            }
        }
    }


    //所有单位刷新
    static public void UnitUpdate(float tm)
    {
        Unit u;
        for (int i = UnitList.Count - 1; i >= 0; i--)
        {
            UnitList[i].update(tm);
        }
    }

    static public List<Unit> GetUnitList()
    {
        List<Unit> list = new List<Unit>();

        for (int i = UnitList.Count - 1; i >= 0; i--)
        {
            if (UnitList[i].removed == false)
            {
                list.Add(UnitList[i]);
            }
        }
        return list;
    }

    //获取名字
    public string getName()
    {
        return this.name;
    }
}
