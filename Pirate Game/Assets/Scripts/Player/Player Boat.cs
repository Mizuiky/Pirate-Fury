using System;
using UnityEngine;

public class PlayerBoat : MonoBehaviour, ICollision, IAnimation
{
    [SerializeField]
    private MoveScript _move;

    [Space(10)]

    [SerializeField]
    private PlayerHealth _healthBase;

    [SerializeField]
    private CannonBase _cannon;

    [SerializeField]
    private InputComponent _input;

    [SerializeField]
    private CollisionBase[] _collisions;

    [SerializeField]
    private Animator _destructionAnimation;

    private Vector3 _startPosition;

    public ComponentType type;

    public PlayerHealth Health { get { return _healthBase; } }

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

        Timer.OnTimerIsOver += StopPlayer;

        _move?.Init();

        _hasCollided = false;

        transform.position = startPosition;

        _destructionAnimation.gameObject.SetActive(false);
    }

    public void Reset()
    {
        transform.position = _startPosition;

        _healthBase.Reset();

        _move.Reset();

        _hasCollided = false;

        _destructionAnimation.gameObject.SetActive(false);
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
        //flash color
    }

    private void OnDeath()
    {
        Debug.Log("OnPlayerDeath");

        _destructionAnimation.gameObject.SetActive(true);

        _destructionAnimation.Play("Destruction");

    }

    public void OnDisablePlayer()
    {
        Debug.Log("OnDisablePlayer");

        _hasCollided = true;
        _move.isMoving = false;

    }

    public void OnEndAnimation()
    {
        OnPlayerDeath?.Invoke();

        _destructionAnimation.gameObject.SetActive(false);

        OnDisablePlayer();
    }
 
    public void StopPlayer()
    {
        Debug.Log("OnStopPlayer");

        _hasCollided = true;
        _move.isMoving = false;

        OnPlayerStop.Invoke();
        OnDisablePlayer();
    }

    public void OnDisable()
    {

        _healthBase.OnKill -= OnDeath;
        _healthBase.OnDamage -= OnDamage;

        Timer.OnTimerIsOver -= OnDisablePlayer;
    }
}
