using System;
using UnityEngine;

public class ShipDeteriorate : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private int _damagedHealthPercentage = 70;

    [SerializeField]
    [Range(1, 100)]
    private int _dyingHealthPercentage = 30;

    [SerializeField]
    private Sprite[] _flags;

    [SerializeField]
    private Sprite[] _boats;

    [SerializeField]
    private SpriteRenderer _shipFlag;

    [SerializeField]
    private SpriteRenderer _shipBoat;

    private float _maxLife;
    private Level _currentState;

    enum Level
    {
        Healthy,
        Damaged,
        Dying
    }

    public void Init(float currentLife, float maxLife)
    {
        _maxLife = maxLife;
        _currentState = GetCurrentState(currentLife);
        UpdateAssets(_currentState);
    }

    private Level GetCurrentState(float currentLife)
    {
        float healthPercentage = currentLife / _maxLife * 100;

        if (healthPercentage < _dyingHealthPercentage)
            return Level.Dying;

        if (healthPercentage < _damagedHealthPercentage)
            return Level.Damaged;

        return Level.Healthy;
    }

    private void UpdateAssets(Level newState)
    {
        int index = (int)newState;
        _shipFlag.sprite = _flags[index];
        _shipBoat.sprite = _boats[index];
    }

    public void UpdateShipState(float currentLife)
    {
        Level newState = GetCurrentState(currentLife);
        if (newState != _currentState)
        {
            _currentState = newState;
            UpdateAssets(newState);
        }
    }
}
