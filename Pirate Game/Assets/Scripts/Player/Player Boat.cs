using System;
using UnityEngine;

public class PlayerBoat : MonoBehaviour
{
    [SerializeField]
    private MoveScript _move;

    [Space(10)]

    [SerializeField]
    private HealthBase _healthBase;

    [SerializeField]
    private CannonBase _cannon;

    [SerializeField]
    private InputComponent _input;

    [SerializeField]
    private Transform _startPosition;

    public HealthBase Health { get { return _healthBase; } }

    public Action OnPlayerDeath;

    public Transform PlayerPosition { get { return transform; } }

    public void Update()
    {
        PlayerInput();
    }

    public void Init(Vector3 startPosition)
    {
        if (_healthBase != null)
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

    private void PlayerInput()
    {

        if (Input.GetKeyDown(_input.shootKey))
            _cannon.StartShoot(PoolType.CannonBall);

        else if (Input.GetKeyDown(_input.tripleShootKey) && !_cannon.isShooting)
            _cannon.StartShoot(PoolType.TripleCannonBall);

        else if (Input.GetKeyUp(_input.shootKey) || Input.GetKeyUp(_input.tripleShootKey))
            _cannon.isShooting = false;

        //Test
        if (Input.GetKeyDown(KeyCode.L))
            _healthBase.Damage(2f);
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
