using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyBase
{
    [Header("Movement Components")]

    [SerializeField]
    private float _speed;

    private Vector2 _direction;

    private Transform target;

    private bool _isMoving;

    private void Update()
    {
        if (IsActive)
        {

            if (target != null && _isMoving)
            {

                _direction = target.position - transform.position;
                _direction.Normalize();

                Debug.DrawRay(transform.position, _direction * 80, Color.green);

                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);

                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, _direction);

                transform.rotation = desiredRotation;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colidiu");

        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("colidiu com o player");

            IDamageable collidedComponent = collision.gameObject.GetComponent<IDamageable>();

            if(collidedComponent != null)
            {
                collidedComponent?.Destroy();

                healthBase.Destroy();

                _isMoving = false;
            }
        }
    }

    public override void Init(Vector3 position, Quaternion rotation)
    {

        base.Init(position, rotation);

        target = GameManager.Instance.PlayerBoat.PlayerPosition;

        _isMoving = true;
    }
}

