using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager
{
    private ComponentType _currentCollidedComponentTag;

    private ComponentType _currentRootComponentTag;

    private GameObject _currentRootComponent;

    private GameObject _currentCollidedObject;

    private IDamageable _rootComponent;

    private IDamageable _targetToDamage;

    public void Init()
    {
        CollisionBase.OnCollision += ManagerCollisions;
    }

    private void ManagerCollisions(GameObject rootComponent, GameObject collidedObject)
    {
        Debug.Log(rootComponent.tag + " Collided "+ " with " + collidedObject.tag);

        try
        {
            Enum.TryParse(collidedObject.tag, out _currentCollidedComponentTag);
            Enum.TryParse(rootComponent.tag, out _currentRootComponentTag);
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
       
        switch (_currentRootComponentTag)
        {
            case ComponentType.Player:

                if (_currentCollidedComponentTag == ComponentType.EnemyChaser)
                {
                    SetTargetDamage(collidedObject, rootComponent);

                    Destroy(collidedObject);
                }
                    
                else if(_currentCollidedComponentTag == ComponentType.EnemyShooter)
                {
                    SetTargetDamage(rootComponent, collidedObject);

                    SetTargetDamage(collidedObject, rootComponent);
                }
                    
                break;

            case ComponentType.EnemyChaser:

                if (_currentCollidedComponentTag == ComponentType.Player)
                    
                    SetTargetDamage(rootComponent, collidedObject);

                    Destroy(rootComponent);

                break;

            case ComponentType.EnemyShooter:

                if (_currentCollidedComponentTag == ComponentType.Player)
                    
                    SetTargetDamage(rootComponent, collidedObject);

                break;

            case ComponentType.CannonBall:

                CannonBallBase ball = rootComponent.GetComponent<CannonBallBase>();

                if(!ball.HasCollided)
                {
                    ball?.OnCollision();

                    IDamageable targetToDamage = collidedObject.GetComponent<IDamageable>();
                    targetToDamage?.Damage(ball.DamageValue);
                }               
                
                   
            break;
        }         
    }

    private void Destroy(GameObject componentToDestroy)
    {

        IDamageable destroy = componentToDestroy.GetComponent<IDamageable>();

        Debug.Log("destroy method " + componentToDestroy.tag);

        if (destroy != null)
        {
            Debug.Log("PASSOU DESTROY ");
            destroy.Destroy();
        }           
    }

    private void SetTargetDamage(GameObject rootComponent, GameObject target)
    {
        _rootComponent = rootComponent.GetComponent<IDamageable>();

        _targetToDamage = target.GetComponent<IDamageable>();

        if(_rootComponent != null && _targetToDamage != null)
            _targetToDamage?.Damage(_rootComponent.TotalDamageToDeal);
    }
}
