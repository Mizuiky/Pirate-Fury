using System;
using UnityEngine;

public class PlayerBoat : MonoBehaviour, ICollision
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
    private CollisionBase[] _collisions;

    private Vector3 _startPosition;

    public ComponentType type;

    public HealthBase Health { get { return _healthBase; } }

    public Action OnPlayerDeath;
    public Action OnPlayerStop;

    public Transform PlayerPosition { get { return transform; } }

    public bool HasCollided { get { return _hasCollided; } set { _hasCollided = value; } }

    private bool _hasCollided;


    public void Update()
    {
        PlayerInput();
    }

    public void Init(Vector3 startPosition)
    {
        _startPosition = startPosition;

        if (_healthBase != null)
        {
            _healthBase.OnKill += OnDeath;
            _healthBase.OnDamage += OnDamage;

            _healthBase.Reset();
        }

        Timer.OnTimerIsOver += OnDisablePlayer;

        _move?.Init();

        _hasCollided = false;

        transform.position = startPosition;
    }

    public void Reset()
    {
        //reset player position

        _healthBase.Reset();

        _move.Reset();

        transform.position = _startPosition;

        _hasCollided = false;
        //reset player animation
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
        //damage animation
        //flash color
    }

    private void OnDeath()
    {
        Debug.Log("OnPlayerDeath");

        OnDisablePlayer();

        //death animation

        //death particle

        //player send message to game manager saying game is over
        OnPlayerDeath?.Invoke();
    }

    public void OnDisablePlayer()
    {
        Debug.Log("OnDisablePlayer");

        _hasCollided = true;

        _move.isMoving = false;
    }

    public void StopPlayer()
    {
        Debug.Log("OnStopPlayer");

        OnPlayerStop.Invoke();
        OnDisablePlayer();
    }
}
