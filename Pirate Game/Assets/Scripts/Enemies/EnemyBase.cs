using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IEnable, ICollision, IAnimation
{
    [SerializeField]
    protected HealthBase healthBase;

    [SerializeField]
    private float _timeToDestroy;

    [SerializeField]
    private int _pointsToGiveOnDeath;

    [SerializeField]
    private Animator _destructionAnimation;

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

    private void Update()
    {
        
    }

    public void Reset()
    {

        EnableColliders(false);

        _hasCollided = false;

        GameManager.Instance.PlayerBoat.OnPlayerDeath += DisableComponent;
        Timer.OnTimerIsOver += DisableComponent;

        _destructionAnimation.enabled = false;

        if (healthBase != null)
        {
            healthBase.OnKill += OnDeath;
            healthBase.OnDamage += OnDamage;

            healthBase.Reset();
        }

        DisableComponent();
    }

    public virtual void Init(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        _destructionAnimation.enabled = false;

        this.target = GameManager.Instance.PlayerBoat.transform;

        GameManager.Instance.PlayerBoat.OnPlayerDeath += DisableComponent;
        Timer.OnTimerIsOver += DisableComponent;

        _hasCollided = false;

        if(healthBase != null)
        {
            healthBase.OnKill += OnDeath;
            healthBase.OnDamage += OnDamage;

            healthBase.Reset();
        } 

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

            _hasCollided = true;

            colliders.SetActive(false);

            //EnableColliders(false);

            GameManager.Instance.WorldController.ScoreController.AddPoints(_pointsToGiveOnDeath);


            _destructionAnimation.enabled = true;

            _destructionAnimation.Play("Destruction");

            Debug.Log("on enemy death");
        }      
    }

    public virtual void DisableComponent()
    {
        _isActive = false;

        _destructionAnimation.enabled = false;

        gameObject.SetActive(false);
    }

    public void OnEndAnimation()
    {
        Invoke("DisableComponent", 0.1f);
    }

    private void OnDisable()
    {
        healthBase.OnKill -= OnDeath;
        healthBase.OnDamage -= OnDamage;

        if(GameManager.Instance.PlayerBoat != null)
            GameManager.Instance.PlayerBoat.OnPlayerDeath -= DisableComponent;

        Timer.OnTimerIsOver -= DisableComponent;
    }
}
