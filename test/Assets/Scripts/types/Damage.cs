using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public Unit source;
    public Unit target;
    public float damage;
    public string damageType;
    public float def;

    public Damage(Unit source,Unit target,float damage,string damageType)
    {
        this.source = source;
        this.target = target;
        this.damage = damage;
        this.damageType = damageType;

        start();
        Run();
    }

    public void start()
    {
        def = target.attribute.Def;
    }

    public void Run()
    {
        damage -= def;
        target.attribute.Hp -= damage;

        if (target.attribute.Hp <= 0)
        {
            target.kill();
        }
    }
}
