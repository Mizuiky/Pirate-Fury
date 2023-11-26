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

    protected ParticleSystem deathParticle;

    protected ParticleSystem damageParticle;

    public Transform PlayerPosition { get { return transform; } }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            _healthBase.Damage(2f);
    }

    public void Init(Vector3 startPosition)
    {
        if(_healthBase != null)
        {
            _healthBase.OnKill += OnDeath;
            _healthBase.OnDamage += OnDamage;

            _healthBase.Reset();
        }

        _move?.Init();

        transform.position = startPosition;
    }

    private void Reset()
    {

    }

    private void OnDamage()
    {

    }

    private void OnDeath()
    {
        Debug.Log("OnPlayerDeath");

        _move.isMoving = false;

        //death animation

        //death particle

        //player send message to game manager saying game is over
        OnPlayerDeath?.Invoke();
    }
}
