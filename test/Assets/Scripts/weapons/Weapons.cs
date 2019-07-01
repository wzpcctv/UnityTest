using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponAction
{
    //空武器
    static public void shotAction_000(Unit u, Weapon wp)
    {
    }
    static public void hitAction_000(Unit u, Weapon wp)
    {
    }

    //武器1
    static public void shotAction_001(Unit u, Weapon wp)
    {
        hitAction_001(u, wp);
    }
    static public void hitAction_001(Unit u, Weapon wp)
    {

        Selector slt = new Selector()
            .inBlock(u.x, u.y, 1500, 1500)
            .isEnemy(u);
        Debug.Log("选取开始");
        foreach (Unit uu in slt.Get())
        {
            uu.showInfo();
        }

        slt.Remove();
    }
}


//枪1
public class weapon_001 : Weapon
{
    public int state = 0;
    public Timer timerState;
    public Action<Unit,Unit> hitUnit;

    //构造函数
    public weapon_001()
    {
        timerState = new Timer();
        timerState.setOnce(false);
    }

    //析构函数
    ~weapon_001()
    {
    }

    //删除武器
    public override void WeaponRemove()
    {
        timerState.Remove();
        timerState = null;
        hitUnit = null;
    }


    //发射
    public void fire()
    {
        Unit dummy = new Unit(owner.team_id, "子弹001", owner.x, owner.y);
        hitUnit = new Action<Unit,Unit>(onHitUnit);
        dummy.addEventBlockUnit(hitUnit);
        dummy.setLifeTime(1);
        dummy.active = new Active(dummy);
        dummy.active.forceX = owner.active.facing * 1000;
    }

    public void onHitUnit(Unit dummy,Unit target)
    {
        if (owner.team_id == target.team_id)
        {
            return;
        }
        
        Damage dmg = new Damage(owner, target, 10, "物理");

        dummy.kill();
    }

    public override void Shot()
    {
        if (canShot())
        {
            fire();
            state += 1;
            //setcd(Math.Max(0.05f, 0.3f - 0.05f * state));
            setcd(0.5f);
            stateCd(1);
        }
    }
    public void stateCd(float time)
    {
        timerState.Start(time, new Action(resetState));
    }
    public void resetState()
    {
        state = 0;
    }
}