using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Unit unit;
    // Start is called before the first frame update
    void Start()
    {
        Unit u = new Unit("农民");
        Unit u2 = new Unit("脚男");

        u = null;
        u2 = null;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.time;
    }

    private Unit[] units;
    static int unitsMax = 100;
    static int unitsNum = 0;
    private Effect[] effets;
    static int Effects = 1000;
    static int bulletsNum = 0;
    private Map map;
}
