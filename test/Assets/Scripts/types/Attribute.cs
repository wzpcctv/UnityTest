using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute
{
    public Attribute(Unit u)
    {
        UnitData data = Table.UnitData[u.id];

        this.Hp = data.hp;
        this.HpMax = data.hp;
        this.Mp = data.mp;
        this.MpMax = data.mp;
        this.Atk = data.atk;
        this.Def = data.def;

        restrictionStunCount = 0;
        stun = false;
    }

    private float hp;
    private float mp;
    private float atk;
    private float def;

    public float Hp_p;
    public float HpMax;
    public float Mp_p;
    public float MpMax;
    public float Atk_p;
    public float Def_p;

    public float Hp
    {
        get
        {
            return hp * (1 + Hp_p / 100);
        }
        set
        {
            hp = value;
        }
    }
    public float Mp
    {
        get
        {
            return mp * (1 + Mp_p / 100);
        }
        set
        {
            mp = value;
        }
    }
    public float Atk
    {
        get
        {
            return atk * (1 + Atk_p / 100);
        }
        set
        {
            atk = value;
        }
    }
    public float Def
    {
        get
        {
            return def * (1 + Def_p / 100);
        }
        set
        {
            def = value;
        }
    }

    public bool stun;
    private int restrictionStunCount;
    public void RestrictionStun(bool b)
    {
        if (b)
        {
            restrictionStunCount += 1;
            if (restrictionStunCount == 1)
            {
                stun = true;
            }
        }
        else
        {
            restrictionStunCount -= 1;
            if (restrictionStunCount == 0)
            {
                stun = false;
            }
        }
    }
    public void RestrictionStun(float time)
    {
        RestrictionStun(true);
        new Timer(time, new System.Action(RestrictionStunTimeAction));
    }
    private void RestrictionStunTimeAction()
    {
        RestrictionStun(false);
    }

    public string attributeInfo()
    {
        string str = "Hp:" + Hp + "(" + hp + "+" + Hp_p + "%)";
        str += " | Mp:" + Mp + "(" + Mp + "+" + Mp_p + "%)";
        str += " | Atk:" + Atk + "(" + atk + "+" + Atk_p + "%)";
        str += " | Def:" + Def + "(" + def + "+" + Def_p + "%)";
        return str;
    }
}
