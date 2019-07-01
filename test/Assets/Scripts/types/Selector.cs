using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector
{
    public string type;
    public List<Unit> unitList;

    public Selector()
    {
        unitList = new List<Unit>();
    }

    public Selector inBlock(float x,float y,float w,float h)
    {
        Block.SelectUnit(unitList, x, y, w, h);
        return this;
    }

    public Selector isEnemy(Unit u)
    {
        for (int i = unitList.Count - 1; i >= 0; i--)
        {
            if (u.team_id == unitList[i].team_id){
                unitList.Remove(unitList[i]);
            }
        }
        return this;
    }

    public List<Unit> Get()
    {
        return unitList;
    }

    public void Remove()
    {
        if (unitList != null)
        {
            unitList.Clear();
            unitList = null;
        }
    }
}
