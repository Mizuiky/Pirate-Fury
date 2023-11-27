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

    public bool IsMoving { get { return _isMoving; } set { _isMoving = value; } }

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

    public override void Init(Vector3 position, Quaternion rotation)
    {

        base.Init(position, rotation);

        target = GameManager.Instance.PlayerBoat.PlayerPosition;

        _isMoving = true;
    }
}

