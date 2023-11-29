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

    [SerializeField]
    private CollisionBase[] _collisions;

    public ComponentType type;

    public HealthBase Health { get { return _healthBase; } }

    public Action OnPlayerDeath;

    public Transform PlayerPosition { get { return transform; } }

    public bool HasCollided = false;

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

        EnableCollisions(true);

        _move?.Init();

        transform.position = startPosition;
    }

    public void Reset()
    {
        EnableCollisions(true);

        //reset player position
        //reset player health
        //reset player animation
        //set is moving
    }

    public void EnableCollisions(bool enable)
    {
        //foreach (CollisionBase collision in _collisions)
        //{
        //    collision.colliderComponent.gameObject.SetActive(enable);

        //    Debug.Log("enabled colliders " + gameObject.tag +  collision.colliderComponent.gameObject.activeInHierarchy);
        //}
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
    }

    private void OnDeath()
    {
        Debug.Log("OnPlayerDeath");

        _move.isMoving = false;

        EnableCollisions(false);

        //death animation

        //death particle

        //player send message to game manager saying game is over
        OnPlayerDeath?.Invoke();
    }
}
