using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Table
{
    static public List<UnitData> UnitData { get; set; }
    static public List<ItemData> ItemData { get; set; }
    static public List<BrickData> BrickData { get; set; }

    static public int getUnitId(string name)
    {
        int id = 0;
        for (int i = 0;i < UnitData.Count; i++)
        {
            if (UnitData[i].name == name)
            {
                id = i;
                break;
            }
        }
        return id;
    }

    static public void UnitDataInit(Unit u)
    {
        UnitData data = Table.UnitData[u.id];
        u.blockUnit = data.blockUnit;
        u.blockBrick = data.blockBrick;
        u.fly = data.fly;

        if (data.weapon!= null)
        {
            u.addWeapon(data.weapon);
        }
        data = null;
    }

    static public int getBrickId(string name)
    {
        int id = 0;
        for (int i = 0; i < BrickData.Count; i++)
        {
            if (BrickData[i].name == name)
            {
                id = i;
                break;
            }
        }
        return id;
    }

    static public int getItemId(string name)
    {
        int id = 0;
        for (int i = 0; i < ItemData.Count; i++)
        {
            if (ItemData[i].name == name)
            {
                id = i;
                break;
            }
        }
        return id;
    }
}
