using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBase
{
    [HideInInspector]
    public Action<float> OnUpdateLife;

    public override void UpdateLife(float value)
    {
        Debug.Log("Update player life " + value);

        base.UpdateLife(value);

        OnUpdateLife?.Invoke(value);
    }
}
