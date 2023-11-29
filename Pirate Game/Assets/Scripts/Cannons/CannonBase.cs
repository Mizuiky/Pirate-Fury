using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBase : MonoBehaviour
{
    [SerializeField]
    protected Transform _firingPosition;

    [SerializeField]
    private float _timeBetweenShoots;

    private PoolType _cannonBallType;

    private IEnable cannonBall;

    private Coroutine _currentCoroutine;

    protected Transform positionToShoot;

    public bool isShooting;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _currentCoroutine = null;
    }

    public void StartShoot(PoolType cannonBallType)
    {
        _cannonBallType = cannonBallType;

        positionToShoot = _firingPosition;

        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        isShooting = true;
        _currentCoroutine = StartCoroutine(ShootCoroutine());
        
    }

    private IEnumerator ShootCoroutine()
    {
        while(isShooting)
        {
            Shoot();

            yield return new WaitForSeconds(_timeBetweenShoots);
        }                   
    }

    public virtual void Shoot()
    {
        cannonBall = GameManager.Instance.pool.GetItem(_cannonBallType);

        //ShootExplosion

        cannonBall?.Init(positionToShoot.position, positionToShoot.rotation);          
    }
}
