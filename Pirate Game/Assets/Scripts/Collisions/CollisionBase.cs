using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBase : MonoBehaviour
{
    [SerializeField]
    private GameObject rootComponent;

    //public Collider2D colliderComponent;

    public delegate void CollisionEventHandler(GameObject component, GameObject collidedObject);
    public static event CollisionEventHandler OnCollision;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(rootComponent);

        ICollision component = rootComponent.GetComponent<ICollision>();

        ICollision objectCollided = collision.gameObject.GetComponentInParent<ICollision>();

        if (!component.HasCollided && !objectCollided.HasCollided)
        {

            GameObject collisionReference = collision.gameObject.GetComponent<CollisionBase>().rootComponent;

            OnCollision?.Invoke(rootComponent, collisionReference);      
        }                   
    }        
}
