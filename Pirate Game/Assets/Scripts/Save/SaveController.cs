using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController
{
    private SaveData _saveData;

    public Action<SaveData> OnLoadData;

    private void Save()
    {

    }

    private void Load()
    {

    }

    private void LoadData()
    {
        OnLoadData?.Invoke(_saveData);
    }
}
