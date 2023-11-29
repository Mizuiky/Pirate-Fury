using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController
{
    private float _timeToSpawn;
    public SpawnerController()
    {
        _timeToSpawn = GameManager.Instance.SaveController.Data.enemySpawnTime;

        Start();
    }

    private void Start()
    {

    }

    public void Reset()
    {

    }
}
