using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool IsActive { get { return _isActive; } set { _isActive = value; } }
    private bool _isActive = false;

    private float _timeToSpawn;

    private float _nextTimeToSpawn;


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

        _nextTimeToSpawn = 0f;

        _isActive = true;

        Debug.Log("start enemy spawner");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnEnemy();
        }

        if(_isActive)
        {
            if (_nextTimeToSpawn <= _timeToSpawn)
                _nextTimeToSpawn += Time.deltaTime;

            else
            {
                Debug.Log("spawn enemy");
                SpawnEnemy();
                _nextTimeToSpawn = 0f;
            }
        }
    }
 
    private void SpawnPlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _playerStartPosition);

        if (player != null)
        {
            _player = player.GetComponent<PlayerBoat>();

            if (_player != null)
            {
                GameManager.Instance.PlayerBoat = _player;
                _player?.Init(_playerStartPosition.position);
            }                         
        }
    }

    private void SpawnEnemy()
    {
        IEnable enemy = Spawn(PoolType.EnemyShooter);

        //GetRandomPosition();

        enemy?.Init(_enemyPositions[0].position, _enemyPositions[0].rotation);
    }

    public IEnable Spawn(PoolType type)
    {
        IEnable poolItem = pool.GetItem(type);

        return poolItem;
    }

    public Vector3 GetRandomPosition()
    {
        return Vector3.one;
    }

    private void OnDisable()
    {
        
    }
}
