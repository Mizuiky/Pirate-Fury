using System;
using UnityEngine;

public class CollisionManager
{
    private ComponentType _currentCollidedComponentTag;

    private ComponentType _currentRootComponentTag;

    private IDamageable _rootComponent;

    private IDamageable _targetToDamage;

    public void Init()
    {
        CollisionBase.OnCollision += ManagerCollisions;
    }

    private void ManagerCollisions(GameObject rootComponent, GameObject collidedObject)
    {
        try
        {
            Enum.TryParse(collidedObject.tag, out _currentCollidedComponentTag);
            Enum.TryParse(rootComponent.tag, out _currentRootComponentTag);
        }
        catch(Exception e)
        {
            Debug.LogError("trying to get the enum: "+e);
        }

        switch (_currentRootComponentTag)
        {
            case ComponentType.Player:

                if (_currentCollidedComponentTag == ComponentType.CannonBall)
                    HitShoot(rootComponent, collidedObject);

                break;

            case ComponentType.EnemyChaser:

                if (_currentCollidedComponentTag == ComponentType.Player)
                {
                    SetTargetDamage(rootComponent, collidedObject);
                    Destroy(rootComponent);
                }
                else if (_currentCollidedComponentTag == ComponentType.CannonBall)
                    HitShoot(rootComponent, collidedObject);

                break;

            case ComponentType.EnemyShooter:

                if (_currentCollidedComponentTag == ComponentType.CannonBall)
                    HitShoot(rootComponent, collidedObject);

                break;
        }         
    }

    private void HitShoot(GameObject rootComponent, GameObject collidedObject)
    {
        CannonBallBase ball = collidedObject.GetComponent<CannonBallBase>();

        if (!ball.HasCollided)
        {
            ball.OnCollision();
            IDamageable targetToDamage = rootComponent.GetComponent<IDamageable>();
            targetToDamage?.Damage(ball.DamageValue);
        }
    }

    private void Destroy(GameObject componentToDestroy)
    {
        IDamageable destroy = componentToDestroy.GetComponent<IDamageable>();

        if (destroy == null)
            throw new Exception("Trying to destroy a non damageable component: "+componentToDestroy.tag);

        destroy.Destroy();
    }

    private void SetTargetDamage(GameObject rootComponent, GameObject target)
    {
        _rootComponent = rootComponent.GetComponent<IDamageable>();
        _targetToDamage = target.GetComponent<IDamageable>();

        if(_rootComponent != null && _targetToDamage != null)
            _targetToDamage?.Damage(_rootComponent.TotalDamageToDeal);
    }
}
