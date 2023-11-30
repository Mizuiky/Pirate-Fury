using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsSlider : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private TextMeshProUGUI _timeText;

    [SerializeField]
    private float _maxValue = 180f;

    [SerializeField]
    private float _minValue = 60f;

    [HideInInspector]
    public float _currentTime;

    public void Init()
    {
        _slider.maxValue = _maxValue;
        _slider.minValue = _minValue;

        _timeText.text = "0";

        _currentTime = _maxValue / 60;

        _slider.value = _maxValue;

    }

    public void SetValue(float value)
    {
        Debug.Log("slider value" + _slider.value);

        _currentTime = value / 60;

        Debug.Log("time in seconds" + _currentTime);

        _timeText.text = _currentTime.ToString("0.00");

        Debug.Log("_timeText.text" + _timeText.text);
    }
}
