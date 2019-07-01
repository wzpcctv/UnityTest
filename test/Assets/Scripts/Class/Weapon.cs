using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

abstract public class Weapon
{
    static public List<Weapon> WeaponData = new List<Weapon>();
    static public List<Action> onShotList = new List<Action>();
    static public List<Action> hitShotList = new List<Action>();

    public string name;
    public Unit owner;
    public Timer timerCd;
    public bool shotable = true;

    abstract public void Shot();
    abstract public void WeaponRemove();


    public Weapon()
    {
        timerCd = new Timer();
        timerCd.setOnce(false);
    }

    public void setcd(float time)
    {
        shotable = false;
        timerCd.Start(time, cdover);
    }
    public void cdover()
    {
        shotable = true;
    }
    public bool canShot()
    {
        return shotable;
    }
    public void Remove()
    {
        timerCd.Remove();
        timerCd = null;
        WeaponRemove();
    }

    public void damage(Unit target,Damage dmg)
    {

    }

    static public void damage(Unit source,Unit target,Damage dmg)
    {

    }

    //static public int getWeaponId(string name)
    //{
    //    for (int i = WeaponList.Count - 1; i >= 0; i++)
    //    {
    //        if (WeaponList[i].name == name)
    //        {
    //            return i;
    //        }
    //    }
    //    return 0;
    //}
    static public Weapon getWeapon(string name)
    {
        switch (name)
        {
            case "武器1":
                Weapon wp = new weapon_001();
                return wp;
        }
        return null;
    }
    
    static public void Init()
    {
    }
}
