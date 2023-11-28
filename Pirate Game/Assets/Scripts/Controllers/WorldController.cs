using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController
{
  
    private SpawnerController _spawnerController;

    private Timer _timer;

    private int _maxTime;
   
    public WorldController()
    {
        GameManager.Instance.SaveController.OnLoadData += LoadData;
        GameManager.Instance.PlayerBoat.OnPlayerDeath += StopWord;

        _spawnerController = new SpawnerController();

        _timer = new Timer(_maxTime);

        //start spawner
    }

    public void Reset()
    {
        _timer.Reset();

        //reset spawner
    }

    private void LoadData(SaveData data)
    {
        _maxTime = data.maxClockTime;
    }

    private void StopWord()
    {
        _timer.isActive = false;

        //stop spawner
    }
}
