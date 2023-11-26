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
    private PoolType _cannonBallType;

    private IEnable cannonBall;

    protected Transform positionToShoot;

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
        positionToShoot = _cannonPosition;
        StartShoot();
    }

    protected void StartShoot()
    {
        cannonBall = GameManager.Instance.pool.GetItem(_cannonBallType);

        //shootParticle?.Play();

        cannonBall?.Init(positionToShoot.position, positionToShoot.rotation);          
    }
}
