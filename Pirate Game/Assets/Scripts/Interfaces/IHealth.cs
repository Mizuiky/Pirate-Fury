using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public float CurrentLife { get; }

    public void Reset();

    public void UpdateLife();
}
