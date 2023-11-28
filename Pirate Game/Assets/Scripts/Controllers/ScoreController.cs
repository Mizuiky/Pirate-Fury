using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController
{
    private int _points;

    public Action<int> OnUpdateScore;

    private void Init()
    {
        _points = 0;
    }

    private void AddPoints(int point)
    {
        _points += point;

        OnUpdateScore?.Invoke(_points);
    }
}
