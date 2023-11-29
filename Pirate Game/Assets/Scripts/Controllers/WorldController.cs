using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController
{
  
    private SpawnerController _spawnerController;

    private ScoreController _scoreController;
    public ScoreController ScoreController { get { return _scoreController; } }

    private Timer _clock;
    public Timer Clock { get { return _clock; } }

    private SaveData _data;

    public WorldController()
    {
        if(GameManager.Instance.SaveController != null)
            GameManager.Instance.SaveController.OnLoadData += LoadData;

        if (GameManager.Instance.PlayerBoat != null)
            GameManager.Instance.PlayerBoat.OnPlayerDeath += StopWord;
    }

    public void Init()
    {
        if (_data != null)
        {
            _spawnerController = new SpawnerController(_data.defaultEnemySpawnTime);
            //start spawner

            _clock = new Timer(_data.maxClockTime);
        }

        _scoreController = new ScoreController();
        _scoreController.Init();
    }

    public void Reset()
    {
        _clock.Reset();
        _scoreController.Reset();

        //reset spawner
    }

    private void LoadData(SaveData data)
    {
        _data = data;
    }

    private void StopWord()
    {
        _clock.isActive = false;

        //stop spawner
    }
}
