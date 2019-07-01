using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//碰撞体，
//目前不做角度处理，认为所有碰撞都是正矩形

//碰撞委托

public class Block
{
    private int id;
    private float target_x = 0;
    private float target_y = 0;
    public float width = 0;
    public float hight = 0;


    public Block()
    {
    }


    public Block(float target_x, float target_y, float width, float hight)
    {
        this.target_x = target_x;
        this.target_y = target_y;
        this.width = width;
        this.hight = hight;
    }


    public void Remove()
    {
    }


    static bool check(float dis, float len, float move)
    {
        return ((dis + move < len) && (-dis - move) < len);
    }

    static float getMove(float dis, float len, float move)
    {
        if (dis > 0)
        {
            return len - dis;
        }
        else if (dis < 0)
        {
            return -dis - len;
        }
        return move;
    }

    public Vector2 canMove_Unit(Unit u, Vector2 vec2)
    {
        bool bAction = false;

        float xMove = vec2.x;
        float yMove = vec2.y;

        float disX;
        float disY;
        float lenX;
        float lenY;

        List<Unit> list = Unit.GetUnitList();
        //单位碰撞
        foreach (Unit unit in list)
        {
            if (u != unit)// && unit.removed == false)
            {
                if (u.blockable == false || unit.blockable == false)
                {

                }
                else
                {
                    bAction = false;
                    disX = u.x - unit.x;
                    disY = u.y - unit.y;
                    lenX = (width + unit.block.width) / 2;
                    lenY = (hight + unit.block.hight) / 2;

                    if (yMove != 0)
                    {
                        if (check(disY, lenY, yMove) && check(disX, lenX, 0))
                        {
                            if (u.blockUnit == 2 && unit.blockUnit == 2)
                            {
                                yMove = getMove(disY, lenY, yMove);
                            }
                            bAction = true;
                        }
                    }
                    if (xMove != 0)
                    {
                        if (check(disX, lenX, xMove) && check(disY, lenY, yMove))
                        {
                            if (u.blockUnit == 2 && unit.blockUnit == 2)
                            {
                                xMove = getMove(disX, lenX, xMove);
                            }
                            bAction = true;
                        }
                    }
                    if (bAction)
                    {
                        Event.BlockUnit(u, unit);
                    }
                }
            }
        }
        list.Clear();
        //for (int i = Unit.UnitList.Count - 1; i >= 0; i--)
        //{
        //    Unit unit = Unit.UnitList[i];
        //}
        return new Vector2(xMove, yMove);
    }



    public Vector2 canMove_Brick(Unit u, Vector2 vec2)
    {
        bool bAction = false;

        float xMove = vec2.x;
        float yMove = vec2.y;

        float disX;
        float disY;
        float lenX;
        float lenY;

        //单位碰撞
        for (int i = Brick.BrickList.Count - 1; i >= 0; i--)
        {
            Brick brick = Brick.BrickList[i];
            if (u.blockable == false || brick.blockable == false)
            {

            }
            else
            {
                bAction = false;
                disX = u.x - brick.x;
                disY = u.y - brick.y;
                lenX = (width + brick.block.width) / 2;
                lenY = (hight + brick.block.hight) / 2;

                if (yMove != 0)
                {
                    if (check(disY, lenY, yMove) && check(disX, lenX, 0))
                    {
                        if (u.blockBrick == 2)
                        {
                            yMove = getMove(disY, lenY, yMove);
                        }
                        bAction = true;
                    }
                }
                if (xMove != 0)
                {
                    if (check(disX, lenX, xMove) && check(disY, lenY, yMove))
                    {
                        if (u.blockBrick == 2)
                        {
                            xMove = getMove(disX, lenX, xMove);
                        }
                        bAction = true;
                    }
                }
                if (bAction)
                {
                    Event.BlockBrick(u, brick);
                }
            }
        }
        return new Vector2(xMove, yMove);
    }

    public Vector2 canMove(Unit u, Vector2 vec2)
    {
        Vector2 vectorR = vec2;
        if (u.blockUnit == null || u.blockUnit == 0)
        {
        }
        else if (u.blockUnit == 2 || u.blockUnit == 1)
        {
            vectorR = canMove_Unit(u, vectorR);
        }

        if (u.blockBrick == null || u.blockBrick == 0)
        {
        }
        else if (u.blockBrick == 2 || u.blockBrick == 1)
        {
            vectorR = canMove_Brick(u, vectorR);
        }

        return vectorR;
    }


    static public void SelectUnit(List<Unit> list, float x, float y, float w, float h)
    {
        //Unit u;
        float disX;
        float disY;
        float lenX;
        float lenY;
        List<Unit> ulist = Unit.GetUnitList();

        foreach (Unit u in ulist)
        {

            //}
            //for (int i = Unit.UnitList.Count - 1; i >= 0; i--)
            //{
            //u = Unit.UnitList[i];
            if (u.block != null && u.alive == true)
            {
                disX = x - u.x;
                disY = y - u.y;
                lenX = (u.block.width + w) / 2;
                lenY = (u.block.hight + h) / 2;

                if (check(disX, lenX, 0) && check(disY, lenY, 0))
                {
                    list.Add(u);
                }
            }
        }

        ulist.Clear();
        //u = null;
    }
}
