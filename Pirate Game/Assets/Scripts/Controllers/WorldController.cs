using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController
{
  
    private SpawnerController _spawnerController;


    private ScoreController _scoreController;
    public ScoreController ScoreController { get { return _scoreController; } }

    private SaveData _data;

    public WorldController()
    {
        if (GameManager.Instance.PlayerBoat != null)
            GameManager.Instance.PlayerBoat.OnPlayerDeath += StopWord;

        _data = GameManager.Instance.SaveController.Data;

        if (_data != null)
        {
            _spawnerController = new SpawnerController(_data.defaultEnemySpawnTime);
            //start spawner
        }

        _scoreController = new ScoreController();
        _scoreController.Init();
    }

    public void Reset()
    {
        _scoreController.Reset();

        //reset spawner
    }

    private void StopWord()
    {
        //stop spawner
    }
}
