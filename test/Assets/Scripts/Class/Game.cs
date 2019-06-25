using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using LitJson;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StreamReader streamreader;
        JsonReader js;
        streamreader = new StreamReader(Application.dataPath + "/table/UnitData.json");
        js = new JsonReader(streamreader);
        table = JsonMapper.ToObject<Table>(js);

        streamreader = new StreamReader(Application.dataPath + "/table/ItemData.json");
        js = new JsonReader(streamreader);
        table = JsonMapper.ToObject<Table>(js);

        for (int i = 0; i < Table.UnitData.Count; i++)
        {
            Debug.Log(Table.UnitData[i].name + " " + Table.UnitData[i].ID + " " + Table.UnitData[i].hp);
            if ( Table.UnitData[i].drop!= null)
            {
                for (int i2 = 0; i2 < Table.UnitData[i].drop.Count; i2++)
                {
                    Debug.Log(Table.UnitData[i].drop[i2]);
                }
            }
        }
        for (int i = 0; i < Table.ItemData.Count; i++)
        {
            Debug.Log(Table.ItemData[i].name + " " + Table.ItemData[i].gold + " " + Table.ItemData[i].atk);
        }

        test();
    }

    public void test()
    {
        Unit u2 = new Unit("脚男", 3, 0);
        Unit u = new Unit("农民", -3, 0);
    }
    // Update is called once per frame
    void Update()
    {
        float tm = Time.deltaTime;
        time = time + tm;

        for (int i = Unit.UnitList.Count - 1; i >= 0; i--)
        {
            Unit.UnitList[i].update(tm);
        }
    }

    static public Table table;

    private float time = 0;

}
