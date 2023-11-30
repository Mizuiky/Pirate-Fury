using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private SaveController _saveData;

    [SerializeField]
    private OptionsPanel optionPanel;

    private SceneControlller sceneController;

    public void Start()
    {
        Init();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PlayerPrefs.DeleteAll();
    }

    private void Init()
    {
        if (sceneController == null)
            sceneController = gameObject.GetComponent<SceneControlller>();

        _saveData = new SaveController();
        _saveData.GetData();

        optionPanel.Init();

        optionPanel.OnEnablePanel(false);
    }

    public void Play()
    {
        Debug.Log("PlayerPrefs ANTES DO PLAY");
        Debug.Log("GameSessionTime " + PlayerPrefs.GetFloat("GameSessionTime"));
        Debug.Log("EnemySpawn " + PlayerPrefs.GetFloat("EnemySpawnTime"));
        Debug.Log("PlayerPoints " + PlayerPrefs.GetInt("Score"));

        _saveData.SetGameSessionData(optionPanel.gameSessionTime);
        _saveData.SetEnemySpawnerData(optionPanel.enemySpawnTime);

        Debug.Log("Play");
        Debug.Log("GameSessionTime " + _saveData.Data.gameSessionTime.ToString());
        Debug.Log("EnemySpawn " + _saveData.Data.enemySpawnTime.ToString());
        Debug.Log("PlayerPoints " + _saveData.Data.playerPoints.ToString());

        Debug.Log("PlayerPrefs DEPOIS DO PLAY");
        Debug.Log("GameSessionTime " + PlayerPrefs.GetFloat("GameSessionTime"));
        Debug.Log("EnemySpawn " + PlayerPrefs.GetFloat("EnemySpawnTime"));
        Debug.Log("PlayerPoints " + PlayerPrefs.GetInt("Score"));

        sceneController.LoadScene(1);
    }
}
