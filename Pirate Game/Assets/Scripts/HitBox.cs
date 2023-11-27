using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colidiu");

        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("colidiu com o player");

            IDamageable collidedComponent = collision.gameObject.GetComponent<IDamageable>();

            if (collidedComponent != null)
            {
                collidedComponent?.Destroy();

                //healthBase.Destroy();

                //_isMoving = false;
            }
        }
    }
}
