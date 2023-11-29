using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class HUD : MonoBehaviour
{
    [Header("Timer")]

    [SerializeField]
    private TextMeshProUGUI _timer;

    [Space(10)]

    [SerializeField]
    private SliderBase _health;

    [Space(10)]

    [SerializeField]
    private TextMeshProUGUI _score;

    public void Init()
    {
        Reset();
    }

    public void UpdateScore(int points)
    {
        _score.text = points.ToString();
    }

    public void UpdateTimer(string clock)
    {
        _timer.text = clock;
    }

    public void Reset()
    {
        _timer.text = "00 : 00";

        _score.text = "0";
    }
}
