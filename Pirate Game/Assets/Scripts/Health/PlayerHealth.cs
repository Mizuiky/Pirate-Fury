using System;
using UnityEngine;

public class PlayerHealth : HealthBase
{
    [HideInInspector]
    public Action<float> OnUpdateLife;

    public override void UpdateLife(float value)
    {
        base.UpdateLife(value);
        OnUpdateLife?.Invoke(value);
    }
}
