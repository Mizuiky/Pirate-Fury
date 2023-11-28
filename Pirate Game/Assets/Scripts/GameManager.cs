using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Pool pool;

    [SerializeField]
    private GameObject _playerPrefab;

    [SerializeField]
    private Transform _playerStartPosition;

    [SerializeField]
    private Transform _enemyStartPosition;

    public PlayerBoat PlayerBoat { get { return _playerBoat; } }

    private PlayerBoat _playerBoat;

    public SaveController SaveController { get { return _saveController; } }

    private SaveController _saveController;

    private WorldController _worldController;

    public WorldController WorldController { get { return _worldController; } }

    private void Awake()
    {
        if (Instance == null)
            Instance = gameObject.GetComponent<GameManager>();

        else
            Destroy(this);
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            InstantiateEnemy();
        }
    }

    private void Init()
    {
        if(pool != null)
            pool.InitPool();

        _worldController = new WorldController();

        StartPlayer();
    }

    private void StartPlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _playerStartPosition);

        if (player != null)
        {
            _playerBoat = player.GetComponent<PlayerBoat>();

            if (_playerBoat != null)
                _playerBoat.Init(_playerStartPosition.position);
        }
    }

    private void ShowEndGame()
    {
        Debug.Log("ShowEndGame");
    }

    private void InstantiateEnemy()
    {
        IEnable enemy = pool.GetItem(PoolType.EnemyShooter);

        enemy?.Init(_enemyStartPosition.position, _enemyStartPosition.rotation);
    }

    //public <T> IntantiateComponent <T> (GameObject prefab, Transform parent) : Where T MonoBehaviour
    //{
    //    Instantiate(prefab, parent)
    //}
}
