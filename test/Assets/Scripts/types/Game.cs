using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Unit unit;
    // Start is called before the first frame update
    void Start()
    {
        units = new Unit[unitsMax];

        Unit u2 = new Unit("脚男", 3, 0);
        Unit u = new Unit("农民",-3,0);
    }

    // Update is called once per frame
    void Update()
    {
        float tm = Time.deltaTime;
        time = time + tm;

        for (int i = 0; i < unitsNum; i++)
        {
            units[i].update(tm);
        }
    }

    public static Unit[] units;
    public static int unitsMax = 100;
    public static int unitsNum = 0;
    public static Effect[] effets;
    public static int Effects = 1000;
    public static int EffectsNum = 0;

    private float time = 0;
}
