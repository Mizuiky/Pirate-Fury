using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController
{
    private SaveData _saveData;

    public SaveData Data { get { return _saveData; } }

    public SaveController()
    {
        _saveData = new SaveData();
        _saveData = MockSaveData(_saveData);

    }
    private void Save()
    {

    }

    public void Load()
    {
        
    }

    private SaveData MockSaveData(SaveData data)
    {
        data.maxClockTime = 0.34f;
        data.defaultEnemySpawnTime = 2f;

        return data;
    }
}
