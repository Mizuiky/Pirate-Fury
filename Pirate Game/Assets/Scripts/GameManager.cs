using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private UIController _UIController;
    public UIController UIController { get { return _UIController; } }


    [SerializeField]
    private CameraController _cameraController;
    public WorldController WorldController { get { return _worldController; } }


    [SerializeField]
    private SpawnerController _spawnerController;
    public SpawnerController SpawnerController { get { return _spawnerController; } }


    public PlayerBoat PlayerBoat { get { return _playerBoat; } set { _playerBoat = value; } }

    private PlayerBoat _playerBoat;


    private SaveController _saveController;
    public SaveController SaveController { get { return _saveController; } }


    private CollisionManager _collisionManager;

    private WorldController _worldController;


    private void Awake()
    {
        if (Instance == null)
            Instance = gameObject.GetComponent<GameManager>();

        else
            Destroy(this);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene " + scene.name + " was loaded ");

        Init();
    }

    private void Init()
    {
      
        Debug.Log("GameManager Init");

        _saveController = new SaveController();
        _saveController.GetData();

        _spawnerController.Init(_saveController.Data.enemySpawnTime);

        Debug.Log("GetData GameManger");

        Timer.OnTimerIsOver += OnEndGame;

        if (_playerBoat != null)
        {
            _playerBoat.OnPlayerDeath += OnEndGame;
            _playerBoat.OnPlayerStop += OnEndGame;
        }

        _cameraController.SetCameraTarget(_playerBoat.transform);

        _collisionManager = new CollisionManager();
        _collisionManager.Init();

        _worldController = new WorldController();

        _UIController.Init();
    }

    public void Restart()
    {

        _spawnerController.Reset();

        _cameraController.SetCameraTarget(_playerBoat.transform);

        _worldController.Reset();

        _UIController.Reset();

    }

    private void OnEndGame()
    {
        Debug.Log("ShowEndGame");

        _spawnerController.IsActive = false;

        _saveController.SetPlayerScore(_worldController.ScoreController.Points);

        _UIController.OpenEndPanel();
    }

    private void OnDisable()
    {
        _playerBoat.OnPlayerDeath -= OnEndGame;
        _playerBoat.OnPlayerStop -= OnEndGame;

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
