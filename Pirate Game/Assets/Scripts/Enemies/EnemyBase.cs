using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IEnable, ICollision
{
    [SerializeField]
    protected HealthBase healthBase;

    [SerializeField]
    private float _timeToDestroy;

    [SerializeField]
    private int _pointsToGiveOnDeath;

    //[SerializeField]
    //private CollisionBase [] _collisions;

    [SerializeField]
    public GameObject colliders;

    private bool _hasCollided;
    public bool HasCollided { get { return _hasCollided; } set { _hasCollided = value; } }

    public ComponentType type;

    protected Transform target;

    private bool _isActive;
    public bool IsActive { get { return _isActive; } }
    public bool Health { get { return healthBase; } }

    private void Start()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnDeath;
            healthBase.OnDamage += OnDamage;

            healthBase.Reset();
        }
    }

    private void Update()
    {
        
    }

    public void Reset()
    {
        healthBase.Reset();

        EnableColliders(false);

        _hasCollided = false;

        GameManager.Instance.PlayerBoat.OnPlayerDeath += OnDisableEnemy;
        Timer.OnTimerIsOver += OnDisableEnemy;

        DisableComponent();
    }

    public virtual void Init(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        this.target = GameManager.Instance.PlayerBoat.transform;

        GameManager.Instance.PlayerBoat.OnPlayerDeath += OnDisableEnemy;
        Timer.OnTimerIsOver += OnDisableEnemy;

        _hasCollided = false;

        healthBase.Reset();

        colliders.SetActive(true);

        EnableColliders(true);

        gameObject.SetActive(true);

        _isActive = true;
    }

    public void EnableColliders(bool enable)
    {

        //foreach (CollisionBase collision in _collisions)
        //{
        //    collision.colliderComponent.gameObject.SetActive(enable);

        //    Debug.Log("enabled colliders " + gameObject.tag + collision.colliderComponent.gameObject.activeInHierarchy);
        //}
    }

    protected virtual void OnDamage()
    {
        //damage animation
    }

    protected virtual void OnDeath()
    {
        Debug.Log("Enemy death");
        //death animation

        if(!_hasCollided)
        {
            Debug.Log("Explosion Animation!!!");

            _hasCollided = true;

            colliders.SetActive(false);

            //EnableColliders(false);

            GameManager.Instance.WorldController.ScoreController.AddPoints(_pointsToGiveOnDeath);

            OnDisableEnemy();
        }      
    }

    public virtual void OnDisableEnemy()
    {
        DisableComponent();
        //StartCoroutine(DisableEnemy());
    }

    private IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(_timeToDestroy);

        DisableComponent();
    }

    public void DisableComponent()
    {

        _isActive = false;
        gameObject.SetActive(false);
    }
}
