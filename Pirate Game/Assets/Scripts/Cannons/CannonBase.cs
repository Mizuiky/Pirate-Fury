using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBase : MonoBehaviour, ICannon
{
    [SerializeField]
    private Transform _cannonPosition;

    [SerializeField]
    private KeyCode _shootKey;

    [SerializeField]
    private float timeBetweenShoots;

    private IEnable cannonBall;

    private bool _isShooting;

    private void Update()
    {
        //if (Input.GetKey(_shootKey))
        //{
        //    _isShooting = true;
        //    Shoot();
        //}    
        //else if(Input.GetKeyUp(_shootKey))
        //    _isShooting = false;

        if (Input.GetKeyDown(_shootKey))
            Shoot();
    }

    public virtual void Shoot()
    {
        StartShoot();

        //StartCoroutine(ShootCoroutine());
    }

    protected virtual IEnumerator ShootCoroutine()
    {
        while(_isShooting)
        {
            StartShoot();

            yield return new WaitForSeconds(timeBetweenShoots);
        }

        _isShooting = false;
    }

    private void StartShoot()
    {
        cannonBall = GameManager.Instance.Pool.GetItem(PoolType.CannonBall);

        //shootParticle?.Play();

        cannonBall?.Init(_cannonPosition.position, _cannonPosition.rotation);          
    }
}
