using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IEnable
{
    [SerializeField]
    protected HealthBase healthBase;

    [SerializeField]
    protected ParticleSystem deathParticle;

    protected ParticleSystem damageParticle;

    [SerializeField]
    private float _timeToDestroy;

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

    protected virtual void OnDamage()
    {
        damageParticle?.Play();
    }

    protected virtual void OnDeath()
    {
        Debug.Log("Enemy death");
        //death animation

        deathParticle?.Play();

        OnDisableEnemy();
    }

    public virtual void Init(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        gameObject.SetActive(true);

        _isActive = true;
    }

    public void DisableComponent()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDisableEnemy()
    {
        StartCoroutine(DisableEnemy());
    }

    private IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(_timeToDestroy);

        DisableComponent();
    }
}
