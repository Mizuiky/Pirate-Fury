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

    [SerializeField]
    private float _damageToDeal;

    private float _currentLife;

    public float CurrentLife { get { return _currentLife; } }

    public float TotalDamageToDeal { get { return _damageToDeal * _damagePercent; } }

    public Action OnKill;
    public Action OnDamage;
        
    public void Reset()
    {
        _currentLife = _startLife;

        healthSlider.Init(_startLife);

        UpdateLife(_currentLife);
    }

    public virtual void Damage(float damage)
    {
        Debug.Log("current life" + _currentLife);

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            _currentLife = 0;

            UpdateLife(_currentLife);

            Kill();

            return;
        }

        Debug.Log("current life on damage" + _currentLife);

        UpdateLife(_currentLife);

        OnDamage?.Invoke();        
    }

    public void Destroy()
    {
        Damage(_currentLife);
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
