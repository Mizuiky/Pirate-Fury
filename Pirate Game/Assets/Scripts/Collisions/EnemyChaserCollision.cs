using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaserCollision : CollisionBase
{
    private IDamageable _enemyChaser;

    public override void Init()
    {
        if (rootReference != null)
            _enemyChaser = rootReference.GetComponent<IDamageable>();
    }

    public override void OnCollision()
    {
        Debug.Log("enemy Destroy");

        _enemyChaser?.Destroy();
    }
}
