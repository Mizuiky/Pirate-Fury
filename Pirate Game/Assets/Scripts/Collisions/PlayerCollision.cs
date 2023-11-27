using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : CollisionBase
{
    private IDamageable _player;

    private IDamageable targetToDamage;

    public override void Init()
    {
        if (rootReference != null)
            _player = rootReference.GetComponent<IDamageable>();          
    }

    public override void OnCollision()
    {
        base.OnCollision();

        targetToDamage = _target.GetComponentInParent<IDamageable>();

        if (targetToDamage != null)
        {
            Debug.Log("player collided with enemy");

            Debug.Log("enemy damage " + targetToDamage.TotalDamageToDeal);

            _player?.Damage(targetToDamage.TotalDamageToDeal);
        }
    }
}
