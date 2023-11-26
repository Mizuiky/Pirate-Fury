using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoat : MonoBehaviour
{
    [SerializeField]
    private MoveScript _move;

    [Space(10)]

    [SerializeField]
    private HealthBase _healthBase;

    [SerializeField]
    private Transform _startPosition;

    public Action OnPlayerDeath;

    private void Start()
    {
        Init();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            _healthBase.Damage(2f);
    }

    public void Init()
    {
        if(_healthBase != null)
        {
            _healthBase.OnKill += OnDeath;

            _healthBase.Reset();
        }

        _move?.Init();

        transform.position = _startPosition.position;
    }

    private void OnDeath()
    {
        //stop player boat
        _move.isMoving = false;

        //death animation

        //death particle

        //player send message to game manager saying game is over
        OnPlayerDeath?.Invoke();
    }
}
