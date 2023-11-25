using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBase : MonoBehaviour, ICannon
{
    [SerializeField]
    protected Transform _cannonPosition;

    [SerializeField]
    protected KeyCode _shootKey;

    [SerializeField]
    protected float timeBetweenShoots;

    private IEnable cannonBall;

    protected Vector3 positionToShoot;

    private void Update()
    {
        ShootInput();
    }

    protected virtual void ShootInput()
    {
        if (Input.GetKeyDown(_shootKey))
            Shoot();
    }

    public virtual void Shoot()
    {
        positionToShoot = _cannonPosition.position;
        StartShoot();
    }

    protected void StartShoot()
    {
        cannonBall = GameManager.Instance.Pool.GetItem(PoolType.CannonBall);

        //shootParticle?.Play();

        cannonBall?.Init(positionToShoot, _cannonPosition.rotation);          
    }
}
