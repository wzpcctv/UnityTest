using UnityEngine;
using UnityEditor;
using System;

public class Active
{
    public Unit hero;

    public float speedX;
    public float speedY;
    public float jumpSpeed;//当前Y速度
    public float jumpSpeedStart;//跳跃初始速度
    public float jumpAccel;//掉落加速度
    //public float jumpHeight;
    //public float jumpHeightMax;
    public int state;//0站立，1起跳,2降落
    public int jumpTimes;//跳跃次数
    public int jumpTimesMax;
    public bool sprintAble;//冲刺CD
    public int sprintTimes;
    public int sprintTimesMax;
    public float forceX;//额外位移
    public float forceY;
    public bool exMove;//强制位移
    public bool exX;
    public bool exY;
    public float facing;//1右，-1左
    public float moveX;//XY移动
    public float moveY;//

    public Active(Unit hero)
    {
        this.hero = hero;
        state = 1;
        speedX = 200;
        speedY = 200;
        jumpSpeed = 0;//当前跳跃速度
        jumpSpeedStart = 1000;
        jumpAccel = 2000;
        jumpTimes = 0;
        jumpTimesMax = 2;
        facing = 1;
        sprintAble = true;
        sprintTimes = 0;
        sprintTimesMax = 1;
        moveX = 0;
        moveY = 0;
    }

    public void Remove()
    {
        this.unit = null;
    }

    //重置状态
    public void reset()
    {
        landing();
        updateOver();
    }

    //落地重置Y相关内容
    public void landing()
    {
        jumpSpeed = 0;
        state = 0;
        jumpTimes = 0;
        sprintTimes = 0;
    }
    //一帧结束，重置数值
    public void updateOver()
    {
        moveX = 0;
        moveY = 0;
    }

    //跳跃
    public void jump() { if (canJump()) { jumpAction(); } }
    public bool canJump()
    {
        return
            jumpTimes < jumpTimesMax
            && hero.attribute.stun == false;
    }
    public void jumpAction()
    {
        jumpTimes += 1;
        state = 1;
        jumpSpeed = jumpSpeedStart * (1 - 0.3f * (jumpTimes - 1));
    }

    //冲锋
    public void sprint() { if (canSprint()) { sprintAction(); } }
    public bool canSprint()
    {
        return sprintAble 
            && sprintTimes < sprintTimesMax 
            && hero.attribute.stun == false ;
    }
    public void sprintAction()
    {
        sprintAble = false;
        jumpSpeed = 150;
        sprintTimes += 1;
        forceX = facing * 1000;
        new Timer(0.2f, new Action(sprintOver));//翻滚动作结束
        new Timer(0.5f, new Action(sprintCdOver));//翻滚CD结束
    }

    public void sprintCdOver() { sprintAble = true; }
    public void sprintOver() { forceX = 0; }

    //向左移动
    public void moveLeft()
    {
        if (hero.attribute.stun)
        {
            return;
        }
        moveX -= speedX;
        facing = -1;
    }
    public void moveRight()
    {
        if (hero.attribute.stun)
        {
            return;
        }
        moveX += speedX;
        facing = 1;
    }

    public Active(Unit unit, float speed_x, float speed_y)
    {
        this.unit = unit;
        this.speed_x = speed_x;
        this.speed_y = speed_y;
    }

    public void update(float tm)
    {
        if (hero.fly == false)
        {
            jumpSpeed -= jumpAccel * tm;
        }
        moveX += forceX;
        moveY += forceY;//jumpSpeed;

        moveY += jumpSpeed;

        bool bX = moveX != 0 && hero.MoveX(moveX * tm);
        bool bY = moveY != 0 && hero.MoveY(moveY * tm);

        if (bY == false)
        {
            if (moveY < 0)
            {
                landing();
            }
            else
            {
                jumpSpeed = 0;
            }
        }
        else
        {
            if (state == 0)
            {
                state = 1;
                jumpTimes = 1;
            }
        }

        updateOver();
    }

    private Unit unit;
    private float base_x;
    private float base_y;
    private float speed_x;
    private float speed_y;
}