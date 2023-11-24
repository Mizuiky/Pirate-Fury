using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnable
{
    public void DisableComponent();

    public void EnableComponent();

    public bool IsActive { get; }
}
