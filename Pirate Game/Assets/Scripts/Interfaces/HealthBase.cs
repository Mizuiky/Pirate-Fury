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

    private float _currentLife;

    public float CurrentLife { get { return _currentLife;  } }

    public Action OnKill;
    public Action OnDamage;
        
    public void Reset()
    {
        _currentLife = _startLife;
    }

    public void Damage(float damage)
    {
        if(_currentLife >= 0)
        {
            _currentLife -= damage * _damagePercent;

            OnDamage?.Invoke();
            return;
        }

        Kill();

    }

    public void Kill()
    {
        OnKill?.Invoke();
    }

    public void UpdateLife()
    {
        //update slider
    }
}
