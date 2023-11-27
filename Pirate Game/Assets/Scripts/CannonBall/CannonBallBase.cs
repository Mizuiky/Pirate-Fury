using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBase : MonoBehaviour, IEnable
{
    [SerializeField]
    private float _timeToDestroy;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _damageValue;

    public float DamageValue { get { return _damageValue; } }

    [Space(10)]

    [SerializeField]
    private ParticleSystem _destroyParticle;

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

    public virtual void Init(Vector3 position, Quaternion rotation)
    {
        transform.position = position;

        transform.localRotation = rotation;

        gameObject.SetActive(true);

        _isActive = true;     
    }

    private void Deactivate()
    {
        StartCoroutine(DisableBallCoroutine());

        DisableComponent();
    }

    private IEnumerator DisableBallCoroutine()
    {
        _destroyParticle?.Play();

        yield return new WaitForSeconds(_timeToDestroy);     
    }

    public void DisableComponent()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }
}
