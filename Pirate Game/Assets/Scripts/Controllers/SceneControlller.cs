using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlller : MonoBehaviour
{
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

        #endif

        Application.Quit();
    }
}
