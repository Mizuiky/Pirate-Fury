using System;
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
    private float _sliderTime;

    public bool isActive;

    public static Action OnTimerIsOver;

    public void Init()
    {
        _maxTime = GameManager.Instance.SaveController.Data.gameSessionTime;
        _maxTime *= 60;

        GameManager.Instance.PlayerBoat.OnPlayerDeath += StopTimer;

        Reset();
    }

    public void Reset()
    {
        _timerText.text = "00 : 00";

        _minutes = 0;
        _seconds = 0;
        _elapsedTime = _maxTime;

        _sliderTime = 0;
        _timerSlider.Init(_maxTime);

        _timerText.text = string.Format("{0:00} : {1:00}", _maxTime / 60, _seconds % 60);

        UpdateSlider();

        isActive = true;
    }

    private void Update()
    {
        if (isActive)
        {
            if (_elapsedTime >= 0)
            {
                _elapsedTime -= Time.deltaTime;

                if (_elapsedTime <= 0)
                {
                    _timerText.text = string.Format("{0:00} : {1:00}", 0, 0);

                    _sliderTime = _maxTime;

                    UpdateSlider();

                    OnTimerIsOver?.Invoke();
                }
                else
                {
                    _minutes = Mathf.FloorToInt(_elapsedTime / 60);
                    _seconds = Mathf.FloorToInt(_elapsedTime % 60);

                    _timerText.text = string.Format("{0:00} : {1:00}", _minutes, _seconds);

                    UpdateSlider();
                }                                       
            }
        }
    }

    private void UpdateSlider()
    {
        _sliderTime += Time.deltaTime;

        _timerSlider.UpdateSlider(_sliderTime);
    }

    private void StopTimer()
    {
        isActive = false;
    }

    private void OnDisable()
    {
        GameManager.Instance.PlayerBoat.OnPlayerDeath -= StopTimer;
    }
}
