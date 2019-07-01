using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Timer
{
    static public List<Timer> TimerList = new List<Timer>();
    public Action OnTimer;
    private float start_time = 0;//开始时间
    private float timeRun = 0;//走过的时间
    private float time = 0;//计时器时间
    private bool loop = false;//是否重复
    private int times = 1;//触发次数
    private bool run = true;//是否运行
    public bool once = true;//是否只运行一次，默认计时器运行一次就删除
    public bool removed = false;

    //构造函数
    public Timer()
    {
        run = false;
        TimerList.Add(this);
    }
    public Timer(float time,System.Action onTimer)
    {
        this.time = time;
        this.OnTimer = onTimer;
        this.run = true;
        TimerList.Add(this);
    }
    public Timer(float time,int times, System.Action onTimer)
    {
        this.time = time;
        this.times = times;
        this.OnTimer = onTimer;
        this.run = true;
        TimerList.Add(this);
    }
    public Timer(float time, bool loop, System.Action onTimer)
    {
        this.time = time;
        this.loop = true;
        this.OnTimer = onTimer;
        this.run = true;
        TimerList.Add(this);
    }

    //运行计时器
    public void Start(float time, System.Action onTimer)
    {
        this.timeRun = 0;
        this.time = time;
        this.OnTimer = onTimer;
        this.run = true;
        this.loop = false;
    }
    public void Start(float time, int times, System.Action onTimer)
    {
        this.timeRun = 0;
        this.time = time;
        this.times = times;
        this.loop = false;
        this.OnTimer = onTimer;
        this.run = true;
    }
    public void Start(float time, bool loop, System.Action onTimer)
    {
        this.timeRun = 0;
        this.time = time;
        this.loop = true;
        this.OnTimer = onTimer;
        this.run = true;
    }

    //是否只运行一次
    public void setOnce(bool b)
    {
        once = b;
    }

    //删除
    public void Remove()
    {
        if (removed)
        {
            return;
        }
        this.run = false;
        this.removed = true;
    }

    public void Run()
    {
        run = true;
    }
    public void Stop()
    {
        run = false;
    }

    public void onTimer()
    {
        OnTimer();
    }

    public void update(float tm)
    {
        if (removed)
        {
            TimerList.Remove(this);
            return;
        }
        if (run == false)
        {
            return;
        }

        timeRun += tm;
        if (timeRun >= time)
        {
            this.onTimer();

            timeRun -= time;
            times -= 1;
            if (times <= 0 && loop == false && once == true)
            {
                this.Remove();
            }
        }
    }


    static public void TimerUpdate(float tm)
    {
        for (int i = TimerList.Count - 1; i >= 0; i--)
        {
            TimerList[i].update(tm);
        }
    }
}
