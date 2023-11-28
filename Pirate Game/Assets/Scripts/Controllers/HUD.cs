using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [Header("Timer")]

    [SerializeField]
    private TextMeshProUGUI _timerMinutes;

    [SerializeField]
    private TextMeshProUGUI _timerSeconds;

    [Space(10)]

    [SerializeField]
    private SliderBase _health;

    [Space(10)]

    [SerializeField]
    private TextMeshProUGUI _score;

    public void UpdateScore(int points)
    {
        _score.text = points.ToString();
    }

    public void UpdateTimer(Clock clock)
    {
        _timerMinutes.text = clock.minutes.ToString();
        _timerSeconds.text = clock.seconds.ToString();
    }
}
