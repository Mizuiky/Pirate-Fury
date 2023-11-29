using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;

    [SerializeField]
    private SliderBase _timerSlider;

    private float _maxTime;

    private float _elapsedTime;

    private int _minutes;

    private int _seconds;

    public bool isActive;

    public Action OnGameEnd;

    public void Init(float maxTime)
    {

        _maxTime = maxTime * 60;

        Reset();
    }

    public void Reset()
    {
        _timerText.text = "00 : 00";

        _minutes = 0;

        _seconds = 0;

        _elapsedTime = 1;

        _timerSlider.Init(_maxTime);

        isActive = true;
    }

    private void Update()
    {
        if (isActive)
        {
            if (_elapsedTime < _maxTime)
            {
                _elapsedTime += Time.deltaTime;

                _minutes = Mathf.FloorToInt(_elapsedTime / 60);
                _seconds = Mathf.FloorToInt(_elapsedTime % 60);

                _timerSlider.UpdateSlider(_elapsedTime);

                _timerText.text = string.Format("{0:00} : {1:00}", _minutes, _seconds);

                Debug.Log(_timerText);

                if (_elapsedTime >= _maxTime)
                {
                    Debug.Log("EndGame Game");
                    OnGameEnd?.Invoke();
                }                                   
            }
        }
    }
}
