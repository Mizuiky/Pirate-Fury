using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController
{
    private SaveData _saveData;

    public Action<SaveData> OnLoadData;

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
        LoadData();
    }

    private void LoadData()
    {
        OnLoadData?.Invoke(_saveData);
    }

    private SaveData MockSaveData(SaveData data)
    {
        data.maxClockTime = 1;
        data.defaultEnemySpawnTime = 2f;

        return data;
    }
}
