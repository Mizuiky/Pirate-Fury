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
       
        _currentRootComponent = rootComponent;
        _currentCollidedObject = collidedObject;
       
        switch (_currentRootComponentTag)
        {
            case ComponentType.Player:

                if (_currentCollidedComponentTag == ComponentType.EnemyChaser)
                    Destroy(_currentCollidedObject);

                else if(_currentCollidedComponentTag == ComponentType.EnemyShooter)
                    SetTargetDamage();

                break;

            //case ComponentType.EnemyChaser:

            //    if (_currentCollidedComponentTag == ComponentType.Player)
            //        Destroy(_currentRootComponent);

            //    break;

            //case ComponentType.EnemyShooter:

            //    if (_currentCollidedComponentTag == ComponentType.Player)
            //        SetTargetDamage();

            //    break;

            case ComponentType.CannonBall:

                if (_currentCollidedComponentTag == ComponentType.Player || _currentCollidedComponentTag == ComponentType.EnemyShooter ||
                    _currentCollidedComponentTag == ComponentType.EnemyChaser)
                {
                    CannonBallBase ball = _currentRootComponent.GetComponent<CannonBallBase>();

                    if(!ball.HasCollided)
                    {
                        ball?.OnCollision();

                        IDamageable targetToDamage = _currentCollidedObject.GetComponent<IDamageable>();
                        targetToDamage?.Damage(ball.DamageValue);
                    }               
                }
                   
                break;
        }         
    }

    private void Destroy(GameObject componentToDestroy)
    {
        SetTargetDamage();

        IDamageable destroy = componentToDestroy.GetComponent<IDamageable>();

        Debug.Log("destroy method " + componentToDestroy.tag);

        if (destroy != null)
        {
            Debug.Log("PASSOU DESTROY ");
            destroy.Kill();
        }           
    }

    private void SetTargetDamage()
    {
        _rootComponent = _currentRootComponent.GetComponent<IDamageable>();

        _targetToDamage = _currentCollidedObject.GetComponent<IDamageable>();

        if(_rootComponent != null && _targetToDamage != null)
            _targetToDamage?.Damage(_rootComponent.TotalDamageToDeal);
    }
}
