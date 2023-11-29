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
    }

    public void GetData()
    {

        if(PlayerPrefs.HasKey("GameSessionTime"))
            _saveData.gameSessionTime = PlayerPrefs.GetFloat("GameSessionTime");
        else
            PlayerPrefs.SetFloat("GameSessionTime", 0f);
 

        if (PlayerPrefs.HasKey("EnemySpawnTime"))
            _saveData.enemySpawnTime = PlayerPrefs.GetFloat("EnemySpawnTime");
        else
            PlayerPrefs.SetFloat("EnemySpawnTime", 0f);


        if (PlayerPrefs.HasKey("Score"))
            _saveData.playerPoints = PlayerPrefs.GetInt("Score");
        else
            PlayerPrefs.SetInt("Score", 0);

        PlayerPrefs.Save();

        Debug.Log("GET DATA");
        Debug.Log("GameSessionTime " + _saveData.gameSessionTime.ToString());
        Debug.Log("EnemySpawn " + _saveData.enemySpawnTime.ToString());
        Debug.Log("PlayerPoints " + _saveData.playerPoints.ToString());

        Debug.Log("GET DATA PlayerPrefs");
        Debug.Log("GameSessionTime " + PlayerPrefs.GetFloat("GameSessionTime"));
        Debug.Log("EnemySpawn " + PlayerPrefs.GetFloat("EnemySpawnTime"));
        Debug.Log("PlayerPoints " + PlayerPrefs.GetInt("Score"));
    }

    public void DeleteKeys()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetGameSessionData(float sessionTime)
    {
        PlayerPrefs.SetFloat("GameSessionTime", sessionTime);
        PlayerPrefs.Save();
    }

    public void SetEnemySpawnerData(float spawnerTime)
    {
        PlayerPrefs.SetFloat("EnemySpawnTime", spawnerTime);
        PlayerPrefs.Save();
    }

    public void SetPlayerScore(int points)
    {
        PlayerPrefs.SetInt("Score", points);
        PlayerPrefs.Save();
    }
}
