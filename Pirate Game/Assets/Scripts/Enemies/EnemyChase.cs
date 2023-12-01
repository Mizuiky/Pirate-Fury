using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyBase
{
    [SerializeField]
    private NavMeshController _navMeshController;

    private Vector2 _direction;

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

                Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, _direction);
                transform.rotation = desiredRotation;
            }
        }
    }

    public override void Init(Vector3 position, Quaternion rotation)
    {
        base.Init(position, rotation);

        _navMeshController.Init(target);

        _isMoving = true;
    }

    public override void DisableComponent()
    {
        _isMoving = false;

        _navMeshController.isActive = false;

        base.DisableComponent();
    }
}

