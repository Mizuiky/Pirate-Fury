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

    [Space(10)]

    [SerializeField]
    private SliderBase _lifeSlider;

    private float _maxLife;

    public void Init()
    {
        Reset();
        _timer.Init();
    }

    public void UpdateScore(int points)
    {
        _score.text = points.ToString();
    }

    public void UpdateLife(float value)
    {
        Debug.Log("UPDATE HUD SLIDER " + value);

        _lifeSlider.UpdateSlider(value);
    }

    public void SetMaxLife(float max)
    {
        _maxLife = max;

        _lifeSlider.Init(_maxLife);
    }

    public void Reset()
    {
        _timer.Reset();

        _score.text = "0";

        //_currentLife = _maxLife;
    }
}
