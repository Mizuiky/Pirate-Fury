using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollision
{
    public string TargetToCollide { get; set; }

    public void OnCollision();
}
