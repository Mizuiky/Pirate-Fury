using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBase : MonoBehaviour, IEnable, ICollision
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

    public ComponentType type;

    public float DamageValue { get { return _damageValue; } }

    private bool _hasCollided;
    public bool HasCollided { get { return _hasCollided; } set { _hasCollided = value; } }

    [Space(10)]

    private bool _isActive;

    private float _currentTime;

    public bool IsActive { get { return _isActive; } }

    protected virtual void Start()
    {

    }

    private void Update()
    {
        if (_isActive)
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

        EnableColliders(true);

        gameObject.SetActive(true);

        _isActive = true;

        _hasCollided = false;
    }

    public void EnableColliders(bool enable)
    {
        //foreach (CollisionBase collision in _collisions)
        //{
        //    collision.colliderComponent.gameObject.SetActive(enable);

        //    Debug.Log("enabled colliders " + collision.colliderComponent.gameObject.activeInHierarchy);
        //}
    }

    public void OnCollision()
    {
    
        StartCoroutine(DisableBallCoroutine());

        DisableComponent();
    }

    private IEnumerator DisableBallCoroutine()
    {
        _hasCollided = true;

        EnableColliders(false);

        yield return new WaitForSeconds(_timeToDestroy);     
    }

    public void DisableComponent()
    {

        _isActive = false;
        gameObject.SetActive(false);     
    }
}
