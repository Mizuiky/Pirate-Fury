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
    }

    public void DeleteKeys()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetGameSessionData(float sessionTime)
    {
        PlayerPrefs.SetFloat("GameSessionTime", sessionTime);
        PlayerPrefs.Save();

        _saveData.gameSessionTime = sessionTime;
    }

    public void SetEnemySpawnerData(float spawnerTime)
    {
        PlayerPrefs.SetFloat("EnemySpawnTime", spawnerTime);
        PlayerPrefs.Save();

        _saveData.enemySpawnTime = spawnerTime;
    }

    public void SetPlayerScore(int points)
    {
        PlayerPrefs.SetInt("Score", points);
        PlayerPrefs.Save();

        _saveData.playerPoints = points;
    }
}
