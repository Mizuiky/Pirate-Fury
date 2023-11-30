using System;
using UnityEngine;

public class HealthBase : MonoBehaviour, IHealth, IDamageable
{
    [SerializeField]
    private float _maxLife;

    [SerializeField]
    private float _startLife;

    [SerializeField]
    private float _damagePercent;

    [SerializeField]
    private SliderBase healthSlider;

    [SerializeField]
    private ShipDeteriorate shipDeteriorate;

    [SerializeField]
    private float _damageToDeal;

    private float _currentLife;
    public float CurrentLife { get { return _currentLife; } }

    public float TotalDamageToDeal { get { return _damageToDeal * _damagePercent; } }

    public Action OnKill;
    public Action OnDamage;


    private void Start()
    {
        _currentLife = _startLife;
    }

    public void Reset()
    {
        _currentLife = _startLife;

        healthSlider.Init(_startLife);
        shipDeteriorate.Init(_startLife, _maxLife);

        UpdateLife(_currentLife);
    }

    public virtual void Damage(float damage)
    {
        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            UpdateLife(0);
            Kill();

            return;
        }

        UpdateLife(_currentLife);
        shipDeteriorate.UpdateShipState(_currentLife);
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
