using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComponentType
{
    Player,
    EnemyChaser,
    EnemyShooter,
    CannonBall
}

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

    [SerializeField]
    private UIController _UIController;
    public UIController UIController { get { return _UIController; } }

    public PlayerBoat PlayerBoat { get { return _playerBoat; } }

    private PlayerBoat _playerBoat;

    private CollisionManager _collisionManager;

    private WorldController _worldController;
    public WorldController WorldController { get { return _worldController; } }

    private SaveController _saveController;
    public SaveController SaveController { get { return _saveController; } }

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

        StartPlayer();

        Debug.Log("GameManager Init");

        _saveController = new SaveController();
        _saveController.GetData();

        Debug.Log("GetData GameManger");

        if (_playerBoat != null)
        {
            _playerBoat.OnPlayerDeath += OnEndGame;
            _playerBoat.OnPlayerStop += OnEndGame;
        }
            
        Timer.OnTimerIsOver += OnEndGame;

        _collisionManager = new CollisionManager();
        _collisionManager.Init();

        _worldController = new WorldController();

        _UIController.Init();
    }

    public void Restart()
    {

        _playerBoat.Reset();

        _worldController.Reset();

        _UIController.Reset();

        pool.Reset();
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

    private void OnEndGame()
    {
        Debug.Log("ShowEndGame");

        _saveController.SetPlayerScore(_worldController.ScoreController.Points);

        _UIController.OpenEndPanel();
    }

    private void InstantiateEnemy()
    {
        IEnable enemy = pool.GetItem(PoolType.EnemyChaser);

        enemy?.Init(_enemyStartPosition.position, _enemyStartPosition.rotation);
    }
}
