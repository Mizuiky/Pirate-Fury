using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBase : MonoBehaviour, IEnable, ICollision, IAnimation
{
    [SerializeField]
    private float _timeToDestroy;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _damageValue;

    [Space(10)]

    [SerializeField]
    private CollisionBase[] _collisions;

    [SerializeField]
    private Animator _animator;

    public ComponentType type;

    public float DamageValue { get { return _damageValue; } }

    private bool _hasCollided;
    public bool HasCollided { get { return _hasCollided; } set { _hasCollided = value; } }

    [Space(10)]

    private bool _isActive;
    private bool _canMove;
    private float _currentTime;

    public bool IsActive { get { return _isActive; } }

    protected virtual void Start()
    {

    }

    private void Update()
    {
        if (_isActive && _canMove)
            transform.position +=  transform.up * _speed * Time.deltaTime;

        if(_currentTime < _timeToDestroy)
            _currentTime += Time.deltaTime;

        else
        {
            _currentTime = 0;
            DisableComponent();
        }
    }

    public void Init(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.localRotation = rotation;

        gameObject.SetActive(true);

        _canMove = true;
        _isActive = true;
        _hasCollided = false;

        _animator.gameObject.SetActive(true);
    }

    public void Reset()
    {
        DisableComponent();

        _canMove = true;
        _isActive = true;
        _hasCollided = false;

        _animator.gameObject.SetActive(true);
    }

    public void EnableColliders(bool enable)
    {
        //TODO: Delete this method
    }

    public void OnCollision()
    {
        if(!_hasCollided)
        {
            _canMove = false;
            _hasCollided = true;

            _animator.Play("CannonBallExplosion");
            
        }
    }

    public void OnEndAnimation()
    {
        Debug.Log("OnCannonBall end animation");

        DisableComponent();
    }

    public void DisableComponent()
    {
        gameObject.SetActive(false);
        _isActive = false;
    }
}
