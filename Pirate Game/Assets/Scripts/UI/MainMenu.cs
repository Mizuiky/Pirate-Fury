using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private OptionsPanel optionPanel;

    private SaveController _saveData;

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
        _saveData.SetGameSessionData(optionPanel.gameSessionTime);
        _saveData.SetEnemySpawnerData(optionPanel.enemySpawnTime);

        sceneController.LoadScene(1);
    }
}
