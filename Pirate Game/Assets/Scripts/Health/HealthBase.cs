using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IHealth, IDamageable
{
    [SerializeField]
    private float _startLife;

    [SerializeField]
    private float _damagePercent;

    [SerializeField]
    private SliderBase healthSlider;

    private float _currentLife;

    public float CurrentLife { get { return _currentLife;  } }

    public Action OnKill;
    public Action OnDamage;
        
    public void Reset()
    {
        _currentLife = _startLife;

        healthSlider.Init(_startLife);
    }

    public virtual void Damage(float damage)
    {
        if (_currentLife <= 0)
        {
            _currentLife = 0;

            UpdateLife(_currentLife);

            Kill();

            return;
        }

        Debug.Log("current life" + _currentLife);

        _currentLife -= damage * _damagePercent;

        Debug.Log("current life on damage" + _currentLife);

        UpdateLife(_currentLife);

        OnDamage?.Invoke();        
    }

    public virtual void Kill()
    {
        OnKill?.Invoke();
    }

    public virtual void UpdateLife(float value)
    {
        healthSlider.UpdateSlider(value);
    }
}
