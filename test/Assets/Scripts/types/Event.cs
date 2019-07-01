using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Judgment
{ 
    //定义一个委托
    public delegate void delegateRun();
    //定义一个事件
    public event delegateRun eventRun;
    //引发事件的方法
    public void Begin()
    {
        eventRun();//被引发的事件
    } 
}
public class RunSports
{ 
    public static int Id;
    private int id;

    public RunSports()
    {
        id = (Id += 1);
        Debug.Log("RunSport Create" + id);
    }

    ~RunSports()
    {
        Debug.Log("RunSport Destroy" + id);
    }
    //定义事件处理方法
    public void Run()
    {
        Debug.Log("运动员开始比赛" + id);
    }





    Judgment judgment = new Judgment();//实例化事件订阅者
    //测试
    public void test()
    {
        RunSports runsport = new RunSports();//实例化事件发布者
        RunSports runsport2 = new RunSports();//实例化事件发布者
        RunSports runsport3 = new RunSports();//实例化事件发布者
        judgment = new Judgment();//实例化事件订阅者
        //订阅事件
        judgment.eventRun += new Judgment.delegateRun(runsport.Run);
        judgment.eventRun += new Judgment.delegateRun(runsport2.Run);
        judgment.eventRun += new Judgment.delegateRun(runsport3.Run);
        //引发事件
        judgment.Begin();

        judgment.eventRun -= new Judgment.delegateRun(runsport2.Run);
    }

}


//单位碰撞
//public class EventBlockUnit
//{
//    public Unit source;
//    public Action<Unit,Unit> action;
//    public EventBlockUnit()
//    {
//    }
//
//    public void Remove()
//    {
//        this.source = null;
//        this.action = null;
//        Event.EventBlockUnitLsit.Remove(this);
//    }
//
//    public void checkAndRun(Unit source,Unit target)
//    {
//        if (this.source == source)
//        {
//            action(source,target);
//        }
//    }
//}


//事件管理器
public class Event
{
    //单位碰撞
    //static public List<EventBlockUnit> EventBlockUnitLsit = new List<EventBlockUnit>();

    static public void UnitCreate(Unit u)
    {
        switch (u.name)
        {
            case "脚男":

                break;

        }
    }


    static public void BlockUnit(Unit source,Unit target)
    {
        source.onBlockUnit(target);
    }

    static public void BlockBrick(Unit source,Brick brick)
    {

    }

    //static public void Init()
    //{
    //    EventBlockUnit ev = new EventBlockUnit();
    //    ev.action = new Action<Unit, Unit>(EventAction.BlockUnit_001);
    //}
    //static public List<Action<Unit>> unitCreate = new List<Action<Unit>>();
    //static public List<Action<Unit>> unitDeath = new List<Action<Unit>>();
    //
    //static public List<Action<Unit, Unit, Damage>> damageAttack = new List<Action<Unit, Unit, Damage>>();
    //static public List<Action<Unit, Unit, Damage>> damageAttacked = new List<Action<Unit, Unit, Damage>>();
}
