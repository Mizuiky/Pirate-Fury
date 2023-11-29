using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnable
{

    public void Init(Vector3 position, Quaternion rotation);

    public void Reset();

    public void DisableComponent();

    public void EnableColliders(bool enable);

    public bool IsActive { get; }
}
