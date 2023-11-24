using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour, IEnable
{
    [SerializeField]
    private ParticleSystem _destroyParticle;

    [SerializeField]
    private float _timeToDestroy;

    private float _speed;

    private Vector3 _direction;

    private float _damage;

    private bool _isActive;

    public bool IsActive { get { return _isActive; } }

    private void Update()
    {
        if (_isActive)
            transform.position += _direction * _speed * Time.deltaTime;
    }

    public void Init(Vector3 direction, Vector3 position)
    {

        EnableComponent();

        transform.position = position;
        _direction = direction;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable collidedComponent = collision.gameObject.GetComponent<IDamageable>();

        if (collidedComponent != null)
            collidedComponent.Damage(_damage);

        Deactivate();
    }

    private void Deactivate()
    {
        StartCoroutine(DestroyBallCoroutine());

        DisableComponent();
    }

    private IEnumerator DestroyBallCoroutine()
    {
        if (_destroyParticle != null)
        {
            _destroyParticle.Play();

            yield return new WaitForSeconds(_timeToDestroy);

        }
    }

    public void DisableComponent()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    public void EnableComponent()
    {
        gameObject.SetActive(true);

        _isActive = true;
    }
}
