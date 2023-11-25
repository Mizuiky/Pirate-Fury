using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour, IEnable
{
    [SerializeField]
    private float _timeToDestroy;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _damage;

    private bool _isActive;

    private float _currentTime;

    public bool IsActive { get { return _isActive; } }

    private void Start()
    {
        _isActive = true;
    }

    private void Update()
    {
        if (_isActive)
            transform.position +=  transform.up * _speed * Time.deltaTime;

        if(_currentTime < _timeToDestroy)
        {
            _currentTime += Time.deltaTime;
        }
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

        _isActive = true;     
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable collidedComponent = collision.gameObject.GetComponent<IDamageable>();

        collidedComponent?.Damage(_damage);

        Deactivate();
    }

    private void Deactivate()
    {
        StartCoroutine(DestroyBallCoroutine());

        DisableComponent();
    }

    private IEnumerator DestroyBallCoroutine()
    {
        //_destroyParticle?.Play();

        yield return new WaitForSeconds(_timeToDestroy);     
    }

    public void DisableComponent()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }
}
