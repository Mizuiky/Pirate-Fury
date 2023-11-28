using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private Clock _clock;

    private int _maxTime;

    private float _currentTime;

    public bool isActive;

    public Timer(int maxTime)
    {
        _clock = new Clock();

        this._maxTime = maxTime;

        Reset();
    }

    public void Reset()
    {
        _currentTime = 0;

        isActive = true;

        StartTimer();
    }

    private void StartTimer()
    {
        if(isActive)
        {
            while (_currentTime < _maxTime)
            {

            }
        }      
    }
}


public class Clock
{
    public float minutes;
    public float seconds;

    public void SetTime(float minutes, float seconds)
    {
        this.minutes = minutes;
        this.seconds = seconds;
    }
}
