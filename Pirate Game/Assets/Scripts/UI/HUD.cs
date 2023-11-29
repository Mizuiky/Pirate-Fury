using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class HUD : MonoBehaviour
{
    [Header("Timer")]

    [SerializeField]
    private Timer _timer;

    [Space(10)]

    [SerializeField]
    private SliderBase _health;

    [Space(10)]

    [SerializeField]
    private TextMeshProUGUI _score;

    public void Init()
    {
        Reset();
        _timer.Init();
    }

    public void UpdateScore(int points)
    {
        _score.text = points.ToString();
    }

    public void Reset()
    {
        _timer.Reset();

        _score.text = "0";
    }
}
