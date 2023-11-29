using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController
{
  
    private SpawnerController _spawnerController;

    private ScoreController _scoreController;
    public ScoreController ScoreController { get { return _scoreController; } }

    public WorldController()
    {
        if (GameManager.Instance.PlayerBoat != null)
            GameManager.Instance.PlayerBoat.OnPlayerDeath += StopWord;


        _spawnerController = new SpawnerController();
        
        _scoreController = new ScoreController();
        _scoreController.Init();
    }

    public void Reset()
    {
        _scoreController.Reset();

        _spawnerController.Reset();
    }

    private void StopWord()
    {
        //stop spawner
    }
}
