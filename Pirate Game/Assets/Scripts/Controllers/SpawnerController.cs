using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController
{
    private float _timeToSpawn;
    public SpawnerController(float timeBetweenEnemies)
    {
        _timeToSpawn = timeBetweenEnemies;
    }
}
