using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{
    [SerializeField]
    private float _distanceToShoot;

    [SerializeField]
    private CannonBase _cannon;

    [SerializeField]
    private PoolType _cannonBallType;

    private Vector3 _direction;

    private bool _canShoot;

    private void Update()
    {

        if (target != null && IsActive)
        {

            _direction = target.position - transform.position;
            _direction.Normalize();

            Debug.DrawRay(transform.position, _direction * 20, Color.magenta);

            Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, _direction);

            transform.rotation = desiredRotation;

            if (Vector3.Distance(transform.position, target.position) <= _distanceToShoot)
                _canShoot = true;

            else
            {
                _canShoot = false;
                _cannon.isShooting = false;
            }
               
            if (_canShoot && !_cannon.isShooting)
                _cannon.StartShoot(_cannonBallType);          
        }       
    }

    public override void Init(Vector3 position, Quaternion rotation)
    {
        base.Init(position, rotation);

        _canShoot = false;
    }

    public override void OnDisableEnemy()
    {
        _canShoot = false;

        base.OnDisableEnemy();
    }
}
