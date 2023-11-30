using UnityEngine;
using UnityEngine.AI;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private Pool pool;

    [Header("Player")]

    [SerializeField]
    private GameObject _playerPrefab;

    [SerializeField]
    private Transform _playerStartPosition;

    private PlayerBoat _player;

    [Header("Enemy")]

    [SerializeField]
    private Transform[] _enemyPositions;

    [SerializeField]
    private int _maxDistance;

    public bool IsActive { get { return _isActive; } set { _isActive = value; } }
    private bool _isActive = false;

    private float _timeToSpawn;
    private float _elapsedTime;


    public void Init(float timeToSpawn)
    {
        if (pool != null)
            pool.InitPool();

        SpawnPlayer();

        _timeToSpawn = timeToSpawn;
        _isActive = true;
    }

    public void Reset()
    {
        pool.Reset();
        _player.Reset();

        _elapsedTime = 0f;
        _isActive = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SpawnEnemy();

        if (!_isActive)
            return;
        
        if (_elapsedTime <= _timeToSpawn)
        {
            _elapsedTime += Time.deltaTime;
            return;
        }
             
        SpawnEnemy();
        _elapsedTime = 0f; 
    }
 
    private void SpawnPlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _playerStartPosition);

        if (player != null && player.TryGetComponent(out _player))
        {    
            GameManager.Instance.PlayerBoat = _player;
            _player.Init(_playerStartPosition.position);
        }
    }

    private PoolType[] GetEnemies()
    {
        return new PoolType[] { PoolType.EnemyChaser, PoolType.EnemyShooter };
    }

    private PoolType GetRandomEnemy()
    {
        PoolType[] enemies = GetEnemies();
        var rand = new System.Random();
        int index = rand.Next(enemies.Length);

        return enemies[index];
    }

    private void SpawnEnemy()
    {
        IEnable enemy = Spawn(GetRandomEnemy()) ;
        Vector3 pos = GetRandomPosition();

        enemy?.Init(pos, _enemyPositions[0].rotation);
    }

    public IEnable Spawn(PoolType type)
    {
        return pool.GetItem(type);
    }

    public Vector3 GetRandomPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere * _maxDistance;
        Vector3 pos = Vector3.zero;

        if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, _maxDistance, NavMesh.AllAreas))
            pos = hit.position;
        
        return pos;
    }

    private void OnDisable()
    {
        _isActive = false;
    }
}
