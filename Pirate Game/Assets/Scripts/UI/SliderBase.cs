using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SliderBase : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private float _minValue;

    [SerializeField]
    private float _duration;

    [SerializeField]
    private Ease _ease;

    private Tween _currentTween;

    public void Init(float max)
    {
        _slider.minValue = _minValue;
        _slider.maxValue = max;
    }

    public void UpdateSlider(float value)
    {
        if (_currentTween != null)
            _currentTween.Kill();

        _currentTween = _slider.DOValue(value, _duration, false).SetEase(_ease);
    }
}
