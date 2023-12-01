using System;

public class ScoreController
{
    private int _points;

    public Action<int> OnUpdateScore;

    public int Points { get { return _points; } }

    public void Init()
    {
        Reset();
    }

    public void AddPoints(int point)
    {
        _points += point;
        OnUpdateScore?.Invoke(_points);
    }

    public void Reset()
    {
        _points = 0;
    }
}
