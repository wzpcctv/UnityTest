using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI
{
    public List<AI> AIList = new List<AI>();
    public Unit hero;

    public AI(Unit hero)
    {
        this.hero = hero;
        AIList.Add(this);
    }

    public void Remove()
    {
        hero = null;
        AIList.Remove(this);
    }
    // Start is called before the first frame update
    // Update is called once per frame
    public void update(float tm)
    {
        
    }
}
