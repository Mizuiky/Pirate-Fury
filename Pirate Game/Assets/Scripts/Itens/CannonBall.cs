using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _destroyParticle;

    [SerializeField]
    private float _timeToDestroy;

    private float _speed;

    private bool _isMoving;

    private Vector3 _direction;

    private float _damage;

    private void Update()
    {
        if (_isMoving)
            transform.position += _direction * _speed * Time.deltaTime;
    }

    public void Init(Vector3 direction)
    {
        gameObject.SetActive(true);

        _isMoving = true;
        _direction = direction;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable collidedComponent = collision.gameObject.GetComponent<IDamageable>();

        if (collidedComponent != null)
            collidedComponent.Damage(_damage);

        DestroyBall();
    }

    public void DestroyBall()
    {
        StartCoroutine(DestroyBallCoroutine());
    }

    public IEnumerator DestroyBallCoroutine()
    {
        if (_destroyParticle != null)
        {
            _destroyParticle.Play();

            yield return new WaitForSeconds(_timeToDestroy);

            gameObject.SetActive(false);
        }
    }
}
