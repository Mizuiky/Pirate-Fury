using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRate : CannonBase
{
    private bool _isShooting;

    [SerializeField]
    protected float timeBetweenShoots;

    //protected override void ShootInput()
    //{
    //    if (Input.GetKey(_shootKey) && !_isShooting)
    //        Shoot();

    //    else if (Input.GetKeyUp(_shootKey))
    //        _isShooting = false;
    //}

    //public override void Shoot()
    //{
    //    _isShooting = true;

    //    StartCoroutine(ShootCoroutine());
    //}

    private IEnumerator ShootCoroutine()
    {
        while (_isShooting)
        {
            Shoot();

            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    //public void TrippleShoot()
    //{
        
    //    for (int i = 0; i < 3; i++)
    //    {
    //        if (i == 0)
    //        {
    //            positionToShoot = _cannonPosition.position * 0.8f;
    //            //positionToShoot.z = _cannonPosition.position.z; // + new Vector3(-_cannonBallOffset, 0, 0);
    //        } 
    //        else if (i == 1)
    //            positionToShoot = _cannonPosition.position;

    //        else if (i == 2)
    //        {
    //            positionToShoot = _cannonPosition.position * 1.2f;

    //            //positionToShoot = _cannonPosition.position + new Vector3(_cannonBallOffset, 0, 0)
    //            //positionToShoot.z = _cannonPosition.position.z;
    //        }


    //        Debug.Log("Cannon position : " + i + " " + positionToShoot);

    //        StartShoot();
    //    }
    //}

    //public void TripleShoot()
    //{
    //    Vector3 b = new Vector3(1, -_cannonPosition.position.x / _cannonPosition.position.y);
    //    Vector3 bu = b / b.magnitude;
    //    Debug.Log("bu : " + bu);


    //    for (int i = 0; i < 3; i++)
    //    {
    //        if (i == 0)
    //        {
    //            positionToShoot = _cannonPosition.position - bu;
    //        }
    //        else if(i == 1)
    //        {
    //            positionToShoot = _cannonPosition.position;
    //        }
    //        else if(i == 2)
    //        {
    //            positionToShoot = _cannonPosition.position + bu;
    //        }
    //        float v1 = Vector3.Dot(_cannonPosition.position, positionToShoot);
    //        float v2 = _cannonPosition.position.magnitude * positionToShoot.magnitude;
    //        Debug.Log("v1 " + v1 + " v2" +v2);
    //        Debug.Log("Cannon position normalized : " + i + " " + positionToShoot.normalized);
    //        Debug.Log("Angle" + Vector3.Angle(positionToShoot, _cannonPosition.position));
    //        Debug.Log("Cannon position : " + i + " " + positionToShoot);
    //        StartShoot();
    //    }
    //}
}
