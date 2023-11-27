using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IEnable
{
    [SerializeField]
    protected HealthBase healthBase;

    [SerializeField]
    private float _timeToDestroy;

    [SerializeField]
    private float _damageValue;

    private bool _isActive;
    public bool IsActive { get { return _isActive; } }

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

    private void Reset()
    {
        
    }

    public virtual void Init(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        gameObject.SetActive(true);

        _isActive = true;
    }

    protected virtual void OnDamage()
    {
        //damage animation
    }

    protected virtual void OnDeath()
    {
        Debug.Log("Enemy death");
        //death animation

        Debug.Log("Explosion Animation!!!");

        OnDisableEnemy();
    }

    public virtual void OnDisableEnemy()
    {
        StartCoroutine(DisableEnemy());
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
