using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTripleShoot : CannonBase
{
    private bool _isShooting;

    [SerializeField]
    private float _cannonBallOffset;

    protected override void ShootInput()
    {
        //if (Input.GetKey(_shootKey) && !_isShooting)
        //    Shoot();

        if (Input.GetKeyDown(_shootKey))
            Shoot();

        else if (Input.GetKeyUp(_shootKey))
            _isShooting = false;
    }

    public override void Shoot()
    {
        _isShooting = true;

        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (_isShooting)
        {
            TrippleShoot();

            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    public void TrippleShoot()
    {
        
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                positionToShoot = _cannonPosition.position * 0.8f;
                //positionToShoot.z = _cannonPosition.position.z; // + new Vector3(-_cannonBallOffset, 0, 0);
            } 
            else if (i == 1)
                positionToShoot = _cannonPosition.position;

            else if (i == 2)
            {
                positionToShoot = _cannonPosition.position * 1.2f;

                //positionToShoot = _cannonPosition.position + new Vector3(_cannonBallOffset, 0, 0)
                //positionToShoot.z = _cannonPosition.position.z;
            }


            Debug.Log("Cannon position : " + i + " " + positionToShoot);

            StartShoot();
        }
    }
}
