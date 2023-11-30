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

    public virtual void Init(Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);

        this.target = GameManager.Instance.PlayerBoat.transform;

        GameManager.Instance.PlayerBoat.OnPlayerDeath += DisableComponent;
        Timer.OnTimerIsOver += DisableComponent;


        if (healthBase != null)
        {
            healthBase.OnKill += OnDeath;
            healthBase.OnDamage += OnDamage;

            healthBase.Reset();
        }

        colliders.SetActive(true);
        gameObject.SetActive(true);

        _isActive = true;
        _hasCollided = false;

        _destructionAnimation.gameObject.SetActive(true);
    }

    public void Reset()
    {
        GameManager.Instance.PlayerBoat.OnPlayerDeath += DisableComponent;
        Timer.OnTimerIsOver += DisableComponent;

        DisableComponent();

        if (healthBase != null)
        {
            healthBase.OnKill += OnDeath;
            healthBase.OnDamage += OnDamage;

            healthBase.Reset();
        }

        _hasCollided = false;

        _destructionAnimation.gameObject.SetActive(true);
    }



    public void EnableColliders(bool enable)
    {
    }

    protected virtual void OnDamage()
    {
        //damage animation
    }

    protected virtual void OnDeath()
    {
        if (_hasCollided)
            return;

        _hasCollided = true;
        colliders.SetActive(false);

        GameManager.Instance.WorldController.ScoreController.AddPoints(_pointsToGiveOnDeath);

        _destructionAnimation.Play("Destruction");
    }

    public virtual void DisableComponent()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    public void OnEndAnimation()
    {
        Invoke(nameof(DisableComponent), 0);
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
