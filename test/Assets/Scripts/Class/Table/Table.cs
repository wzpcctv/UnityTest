using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Table
{
    static public List<UnitData> UnitData { get; set; }
    static public List<ItemData> ItemData { get; set; }

    static public int getUnitId(string name)
    {
        int id = 0;
        for (int i = 0;i < UnitData.Count; i++)
        {
            if (UnitData[i].name == name)
            {
                Debug.Log("获取单位ID " + i + ":" + name);
                id = i;
                break;
            }
        }
        return id;
    }
}
