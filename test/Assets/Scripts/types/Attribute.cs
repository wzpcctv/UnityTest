using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute
{
    public Attribute(Unit unit)
    {

    }


    private float hp;
    private float mp;
    private float atk;
    private float def;

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
            return atk * (1 + Def_p / 100);
        }
        set
        {
            def = value;
        }
    }

    public float Hp_p;
    public float Mp_p;
    public float Atk_p;
    public float Def_p;
}
