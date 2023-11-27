using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void Damage(float damage);

    public float TotalDamageToDeal { get; }

    public void Destroy();

    public void Kill();
}
