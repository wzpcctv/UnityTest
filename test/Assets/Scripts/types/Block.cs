using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//碰撞体，
//目前不做角度处理，认为所有碰撞都是正矩形
public class Block
{
    public Block()
    {
    }

    public Block(F2 obj)
    {
    }

    public Block(F2 obj,float target_x, float target_y, float width,float higth)
    {
        this.obj = obj;
        this.target_x = target_x;
        this.target_y = target_y;
        this.width = width;
        this.higth = higth;

        if (width == 0 || higth == 0)
        {
            obj.blockable = false;
        }

        id = blocksNum;
        blocks[blocksNum] = this;
        blocksNum += 1;
    }


    //检测碰撞
    public bool canMove(F2 obj2)
    {
        if ( obj.blockable == true || obj2.blockable == true ){
            return true;
        }
        if ( ( (obj.x - obj2.x) * 2 < width + obj2.block.width || (obj.x - obj2.x) * 2 > - (width + obj2.block.width)) && ((obj.y - obj2.y) * 2 < higth + obj2.block.higth || (obj.y - obj2.y) * 2 > -(higth + obj2.block.higth)) )
        {
            return false;
        }
        return true;
    }

    public bool canMove(Vector2 vec2)
    {
        float xx = obj.x + vec2.x;
        float yy = obj.y + vec2.y;
        bool b = true;
        for (int i = 0; i < Game.unitsNum; i++)
        {
            Unit obj2 = Game.units[i];
            if (this.obj != obj2)
            {
                //Debug.Log(xx - obj2.x);
                //Debug.Log(yy - obj2.y);
                //Debug.Log(width + obj2.block.width);
                //Debug.Log(higth + obj2.block.higth);

                bool b1 = ((xx - obj2.x) * 2 < width + obj2.block.width);
                bool b2 = (-(xx - obj2.x) * 2 < (width + obj2.block.width));
                bool b3 = b1 || b2;
                //Debug.Log(xx);
                //Debug.Log(obj2.x);
                //Debug.Log(this.width);
                //Debug.Log(obj2.block.width);
                Debug.Log(xx - obj2.x);
                Debug.Log(width + obj2.block.width);
                Debug.Log( -(width + obj2.block.width));
                Debug.Log(b1);
                Debug.Log(b2);
                Debug.Log(b3);


                if (obj.blockable == false || obj2.blockable == false)
                {

                }
                else if (
                    (
                           (
                               ((xx - obj2.x) * 2 < width + obj2.block.width)
                               &&
                               (-(xx - obj2.x) * 2 < (width + obj2.block.width))
                           )
                       )
                   &&
                       (
                           ((yy - obj2.y) * 2 < higth + obj2.block.higth)
                           ||
                           (-(yy - obj2.y) * 2 < (higth + obj2.block.higth))
                       )
                    )
                {
                    Debug.Log("jump");
                    return false;
                }
            }
        }
        return b;
    }

    private int id;
    private F2 obj;
    private float target_x = 0;
    private float target_y = 0;
    public float width = 0;
    public float higth = 0;

    public static Block[] blocks = new Block[1000];
    public static int blocksNum = 0;
}
