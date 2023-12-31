using UnityEngine;

public interface IEnable
{
    public void Init(Vector3 position, Quaternion rotation);
    public void Reset();
    public void DisableComponent();
    public bool IsActive { get; }
}
