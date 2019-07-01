using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Control
{
    //按键bool
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool space;
    public bool shift;
    public bool F;

    public Unit hero;
    public Active active;

    public Control()
    {
    }

    public Control(Unit hero)
    {
        setHero(hero);
    }
    public void Remove()
    {
        hero = null;
        active = null;
    }

    public void reset()
    {
        up = false;
        down = false;
        left = false;
        right = false;
        space = false;
        shift = false;
        F = false;
    }

    public void setHero(Unit u)
    {
        hero = u;
        active = hero.active;
    }



    public void heroMove(float tm)
    {
        //如果没有操纵的英雄则退出
        if (hero == null)
        {
            return;
        }

        //跳跃
        if (space)
        {
            active.jump();
            space = false;
        }

        //冲刺
        if (shift)
        {
            active.sprint();
            shift = false;
        }

        if (F)
        {
            hero.Fire();
        }

        //左右移动
        if (left)
        {
            active.moveLeft();
        }
        else if (right)
        {
            active.moveRight();
        }
    }

    public void update(float tm)
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            up = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            down = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            space = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shift = false;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            F = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            up = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            down = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            space = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shift = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            F = true;
        }

        heroMove(tm);
        //reset();
    }
}
