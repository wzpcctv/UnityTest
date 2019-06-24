using UnityEngine;
using UnityEditor;

public class Action
{
    public Action()
    {

    }

    public Action(F2 obj,float speed_x,float speed_y)
    {
        this.obj = obj;
        this.speed_x = speed_x;
        this.speed_y = speed_y;
    }

    public void update(float time)
    {
        obj.Move(new Vector2(speed_x * time, speed_y * time));
    }

    private F2 obj;
    private float base_x;
    private float base_y;
    private float speed_x;
    private float speed_y;
}