using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBase : MonoBehaviour, ICollision
{
    [SerializeField]
    protected GameObject rootReference;

    [SerializeField]
    private string _targetToCollide;

    protected GameObject _target;

    public string TargetToCollide { get { return _targetToCollide; } set { _targetToCollide = value; } }

    private void Start()
    {
        Init();
    }

    public virtual void Init() { }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(_targetToCollide))
        {
            Debug.Log(rootReference.tag.ToString() + " " + "collided with " + collision.collider.tag.ToString());

            _target = collision.gameObject;

            if (_target != null)
                OnCollision();
        }
    }

    public virtual void OnCollision() 
    {
        
    } 
}
