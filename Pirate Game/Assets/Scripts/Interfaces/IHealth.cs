using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public void Reset();

    public void UpdateLife(float value);

    public float CurrentLife { get; }
}
