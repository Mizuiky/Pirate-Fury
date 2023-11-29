using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private int _maxTime;

    private float _currentTime;

    private string _timer;

    public bool isActive;

    public Action<string> OnTimeUpdate;

    public Timer(int maxTime)
    {
        this._maxTime = maxTime;

        Reset();
    }

    public void Reset()
    {
        _currentTime = 0;

        isActive = true;

        if(_maxTime > 0)
            StartTimer();
    }

    private void StartTimer()
    {
        if(isActive)
        {
            while (_currentTime < _maxTime)
            {
                _currentTime += Time.deltaTime;

                _timer = String.Format("H:mm", _currentTime);

                Debug.Log(_timer);

                OnTimeUpdate?.Invoke(_timer);
            }
        }      
    }
}
